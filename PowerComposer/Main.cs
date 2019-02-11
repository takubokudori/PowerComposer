/* A Powerful Composer for Fiddler*/

using Fiddler;
using System;
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
            string headerString = BuildHeader(
                _oView.MethodTxt.Text,
                _oView.URITxt.Text,
                _oView.VersionTxt.Text,
                _oView.HeaderTxt.Text);
            RequestGenerator rgh = new RequestGenerator(headerString, _oView.GetDict());
            while (rgh.HasNext())
            {
                if ((headerString = rgh.Generate()).Equals(""))
                {
                    // An error occured.
                    break;
                }

//                MessageBox.Show(headerString);
                if (!_header.AssignFromString(headerString))
                {
                    // Failed to parse
                    MessageBox.Show(@"Failed to parse header!");
                    return;
                }

                string bodyString = _oView.BodyTxt.Text;
//                bodyString = parseRequest(bodyString);
                byte[] bodyBytes = new byte[0];
                if (_oView.BodyTxt.Text.Length > 0)
                {
                    bodyBytes = CONFIG.oBodyEncoding.GetBytes(bodyString);
                    if (_header["Content-Encoding"].Equals("gzip") && !_header["Transfer-Encoding"].Equals("gzip"))
                        // GZIP Encode
                        bodyBytes = Utilities.GzipCompress(bodyBytes);
                    _header["Content-Length"] = bodyBytes.Length.ToString();
                }

                Send(_header, bodyBytes);
            }
        }

        private static void Send(HTTPRequestHeaders header, byte[] bodyBytes)
        {
            FiddlerApplication.oProxy.SendRequest(header, bodyBytes, null, null);
        }


        private static bool EncodeRequestIfNeed(ref byte[] b)
        {
            return false;
        }

        private static string BuildRequest(string method, string url, string version, string headers, string body)
        {
            return $"{method} {url} {version}\n{headers}\n\n{body}";
        }

        private static string BuildHeader(string method, string url, string version, string headers)
        {
            return $"{method} {url} {version}\n{headers}";
        }
    }
}