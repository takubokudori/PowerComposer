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
using System.Collections.Specialized;
using System.Text;
using System.Windows.Forms;

[assembly: Fiddler.RequiredVersion("2.3.5.0")]

namespace PowerComposer
{
    public class PowerComposer : IFiddlerExtension
    {
        private const string PCName = "PowerComposer"; // Generated By PowerComposer flag
        private const string RedirNowFlag = "x-PC-now-redir";
        private const string RedirMaxFlag = "x-PC-max-redir";
        private static TabPage _oPage;
        private static PowerComposerView _oView;

        public static bool IsFollowRedirection(Session oSession)
        {
            if (oSession["root"] != PCName) return false;
            if (!int.TryParse(oSession[RedirNowFlag], out var now) ||
                !int.TryParse(oSession[RedirMaxFlag], out var max)) return false;
            return now < max;
        }

        public static void IncrementRedir(ref Session oSession)
        {
            if (!int.TryParse(oSession[RedirNowFlag], out var now)) return;
            oSession[RedirNowFlag] = (now + 1).ToString();
        }


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
            var mic = FiddlerObject.UI.mnuSessionContext.MenuItems;
            mic[FindMenuIndexByText(mic,"R&eplay")].MenuItems
                .Add("Reissue from &PowerComposer", ReissueOnClick); //Replay ContextMenu
        }

        private static void ReissueOnClick(object o, EventArgs e)
        {
            Session s = FiddlerObject.UI.GetFirstSelectedSession();
            _oView.CopySessionToForm(s);
            FiddlerApplication.UI.tabsViews.SelectTab(_oPage);
        }

        private static int FindMenuIndexByText(Menu.MenuItemCollection mic, string s)
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
            // build
            string[] sarr =
            {
                _oView.MethodTxt.Text,
                _oView.URITxt.Text,
                _oView.VersionTxt.Text,
                _oView.HeaderTxt.Text,
                _oView.BodyTxt.Text
            };
            RequestGenerator rgh = new RequestGenerator(sarr, _oView.GetDict())
            {
                ErrorByUndefinedVar = _oView.IsErrorByUndefinedVar
            };
            while (rgh.HasNext())
            {
                try
                {
                    sarr = rgh.Generate();
                    if (_oView.IsFixHostHeader)
                    {
                        Send(sarr[0], sarr[1], sarr[2], sarr[3], sarr[4], null, sarr[1]);
                    }
                    else
                    {
                        Send(sarr[0], sarr[1], sarr[2], sarr[3], sarr[4]);
                    }
                }
                catch (GenerateException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        public static Session Send(string method, string url, string version, string headers, string bodyString,
            StringDictionary oNewFlags = null, string hostname = null)
        {
            string headerString = BuildHeader(method, url, version, headers);
            HTTPRequestHeaders header = new HTTPRequestHeaders();
            if (!header.AssignFromString(headerString))
            {
                // error
                MessageBox.Show(@"Failed to AssignFromString");
                return null;
            }

            if (hostname != null) OverrideHost(ref header, hostname);

            Session oSession = Send(header, GetBodyBytes(header, bodyString), oNewFlags);

            return oSession;
        }

        public static Session Send(string method, string url, string version, string headers, byte[] bodyBytes,
            StringDictionary oNewFlags = null, string hostname = null)
        {
            string headerString = BuildHeader(method, url, version, headers);
            HTTPRequestHeaders header = new HTTPRequestHeaders();
            if (!header.AssignFromString(headerString))
            {
                // error
                MessageBox.Show(@"Failed to AssignFromString");
                return null;
            }

            if (hostname != null) OverrideHost(ref header, hostname);
            Session oSession = Send(header, bodyBytes);

            return oSession;
        }

        public static Session Send(HTTPRequestHeaders header, byte[] bodyBytes, StringDictionary oNewFlags = null,
            string hostname = null)
        {
            if (oNewFlags == null)
            {
                oNewFlags = new StringDictionary
                    {["root"] = PCName}; // Generated by PowerComposer Flag
                if (_oView.MaxFollowRedirect > 0)
                {
                    oNewFlags[RedirNowFlag] = "0";
                    oNewFlags[RedirMaxFlag] = _oView.MaxFollowRedirect.ToString();
                }

                if (_oView.IsFixContentLength) oNewFlags["x-Builder-FixContentLength"] = "PowerComposer-required";
                if (_oView.IsAutoAuth) oNewFlags["x-AutoAuth"] = "PowerComposer-required";
                if (_oView.IsInspectSession) oNewFlags["x-breakrequest"] = "PowerComposer-required";
            }

            if (hostname != null) OverrideHost(ref header, hostname);
            Session oSession = FiddlerApplication.oProxy.SendRequest(header, bodyBytes, oNewFlags, null);
            return oSession;
        }

        private static void OverrideHost(ref HTTPRequestHeaders header, string hostname)
        {
            if (hostname != null)
            {
                int k = hostname.IndexOf(@"://", StringComparison.Ordinal);
                if (k != -1) hostname = hostname.Substring(k + 3);
                k = hostname.IndexOf(@"/", StringComparison.Ordinal);
                if (k != -1) hostname = hostname.Substring(0, k);
                header["host"] = hostname;
            }
        }

        private static byte[] GetBodyBytes(HTTPRequestHeaders header, string bodyString)
        {
            byte[] bodyBytes = new byte[0];
            if (!string.IsNullOrEmpty(bodyString))
            {
                bodyBytes = Encoding.Unicode.GetBytes(bodyString);
                bodyBytes = EncodeRequestIfNeed(ref header, bodyBytes);
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