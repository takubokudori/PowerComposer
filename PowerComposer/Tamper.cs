using System.Windows.Forms;
using Fiddler;

namespace PowerComposer
{
    public class Tamper : IAutoTamper
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
                if (Utilities.IsRedirectStatus(oSession.responseCode))
                {
                    if (oSession.GetRedirectTargetURL().Length != 0)
                    {
                        PowerComposer.IncrementRedir(ref oSession);
                        oSession["x-PC-host"] = "host";
                        PowerComposer.Send("GET",
                            oSession.GetRedirectTargetURL(),
                            oSession.RequestHeaders.HTTPVersion,
                            oSession.RequestHeaders.ToString(false, false),
                            "",
                            oSession.oFlags,
                            oSession.GetRedirectTargetURL());
                    }
                }
            }
        }

        public void OnBeforeReturningError(Session oSession)
        {
        }
    }
}