﻿/* A Powerful Composer for Fiddler*/
/*
MIT License

Copyright (c) 2019 takubokudori

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */

using Fiddler;
using System;
using System.Security.Cryptography;
using System.Windows.Forms;

[assembly: Fiddler.RequiredVersion("2.3.5.0")]

namespace PowerComposer
{
    public class PowerComposer : IFiddlerExtension
    {
        private static TabPage _oPage;
        private static PowerComposerView _oView;
        private static HTTPRequestHeaders _header;

        public PowerComposer()
        {
        }

        public void OnLoad()
        {
            // Create PowerComposer tab.
            _oPage = new TabPage("PowerComposer");
            _oView = new PowerComposerView();
            _oPage.Controls.Add(_oView);
            _oView.Dock = DockStyle.Fill;
            FiddlerApplication.UI.tabsViews.TabPages.Add(_oPage);
            FiddlerObject.UI.mnuSessionContext.MenuItems[12].MenuItems
                .Add("Reissue from &PowerComposer", ReissueOnClick); //Replay ContextMenu
            _header = null;
        }

        private static void ReissueOnClick(object o, EventArgs e)
        {
            Session s = FiddlerObject.UI.GetFirstSelectedSession();
            _header = s.RequestHeaders;
            _oView.MethodTxt.Text = _header.HTTPMethod.Trim();
            _oView.URITxt.Text = s.fullUrl;
            _oView.VersionTxt.Text = _header.HTTPVersion.Trim();
            string srhStr = _header.ToString();
            _oView.HeaderTxt.Text =
                srhStr.Substring(srhStr.IndexOf("\n", StringComparison.Ordinal) + 1).Trim('\r', '\n');
            _oView.BodyTxt.Text = s.GetRequestBodyAsString();
            FiddlerApplication.UI.tabsViews.SelectTab(_oPage);
        }

        private int FindMenuIndexByText(System.Windows.Forms.Menu.MenuItemCollection mic, string s)
        {
            for (var i = 0; i < mic.Count; i++)
            {
                if (mic[i].Text.Contains(s)) return i;
            }

            return -1;
        }


        public void OnBeforeUnload()
        {
        }


        public static void Execute()
        {
            // build header
            string[] sarr = new string[]
            {
                _oView.MethodTxt.Text,
                _oView.URITxt.Text,
                _oView.VersionTxt.Text,
                _oView.HeaderTxt.Text,
                _oView.BodyTxt.Text
            };
            RequestGenerator rgh = new RequestGenerator(sarr, _oView.GetDict());
            rgh.ErrorByUndefinedVar = _oView.IsErrorByUndefinedVar();
            while (rgh.HasNext())
            {
                sarr = rgh.Generate();


                Send(sarr[0], sarr[1], sarr[2], sarr[3], GetBodyBytes(sarr[4]));
            }
        }

        private static Session Send(string method, string url, string version, string headers, byte[] bodyBytes)
        {
            string headerString = BuildHeader(method, url, version, headers);
            HTTPRequestHeaders header = new HTTPRequestHeaders();
            if (!header.AssignFromString(headerString))
            {
                // error
                return null;
            }

            Session oSession = Send(header, bodyBytes);
            if (_oView.IsFollowRedirect()) // redirect
            {
                switch (oSession.responseCode)
                {
                    case 301: // Moved Permanently
                    case 302: // Found
                    case 303: // See Other
                    case 307: // Temporary Redirect
                    case 308: // Permanent Redirect
                        if (!oSession.GetRedirectTargetURL().Equals(""))
                        {
                            Send("GET", oSession.GetRedirectTargetURL(), version, headers, null);
                        }

                        break;
                }
            }

            return oSession;
        }

        private static Session Send(HTTPRequestHeaders header, byte[] bodyBytes)
        {
            Session oSession = FiddlerApplication.oProxy.SendRequest(header, bodyBytes, null, null);
            return oSession;
        }


        private static byte[] GetBodyBytes(string bodyString)
        {
            byte[] bodyBytes = new byte[0];
            if (!string.IsNullOrEmpty(bodyString))
            {
                bodyBytes = CONFIG.oBodyEncoding.GetBytes(bodyString);
                bodyBytes = EncodeRequestIfNeed(ref _header, bodyBytes);
                if (_oView.IsFixContentLength()) _header["Content-Length"] = bodyBytes.Length.ToString();
            }

            return bodyBytes;
        }

        private static byte[] EncodeRequestIfNeed(ref HTTPRequestHeaders header, byte[] bodyBytes)
        {
            if (header["Content-Encoding"].Equals("gzip") && !header["Transfer-Encoding"].Equals("gzip"))
            {
                // GZIP Encode
                bodyBytes = Utilities.GzipCompress(bodyBytes);
            }

            return bodyBytes;
        }

        private static string BuildRequest(string method, string url, string version, string headers, string body)
        {
            return $"{method} {url} {version}\n{headers}\n\n{body}";
        }

        private static string BuildStatusLine(string method, string url, string version)
        {
            return $"{method} {url} {version}";
        }

        private static string BuildHeader(string line, string headers)
        {
            return $"{line}\n{headers}";
        }

        private static string BuildHeader(string method, string url, string version, string headers)
        {
            return BuildHeader(BuildStatusLine(method, url, version), headers);
        }
    }
}