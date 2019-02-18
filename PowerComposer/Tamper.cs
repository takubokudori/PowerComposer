using System.Windows.Forms;
using Fiddler;

namespace PowerComposer
{
    public class Tamper : IAutoTamper2
    {
        public void OnLoad()
        {
        }

        public void OnBeforeUnload()
        {
        }

        public void AutoTamperRequestBefore(Session oSession)
        {
        }

        public void AutoTamperRequestAfter(Session oSession)
        {
        }

        public void AutoTamperResponseBefore(Session oSession)
        {
        }

        public void AutoTamperResponseAfter(Session oSession)
        {
            if (PowerComposer.IsFollowRedirection(oSession)) // redirect
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
                            PowerComposer.Send("GET",
                                oSession.GetRedirectTargetURL(),
                                oSession.RequestHeaders.HTTPVersion,
                                PowerComposer.TrimStatusLineFromHeader(oSession.RequestHeaders.ToString()),
                                null);
                        }

                        break;
                }
            }
        }

        public void OnBeforeReturningError(Session oSession)
        {
        }

        public void OnPeekAtResponseHeaders(Session oSession)
        {
        }
    }
}