using System;
using System.Composition;
using System.Net;
using XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer;

namespace XElement.RedYellowBlue.UI.UWP.Pages.Welcome
{
    [Shared] [Export( typeof( ILoginRecognizer ) )]
    internal class MefLoginRecognizer : 
        global::XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer.LoginRecognizer
    {
#region not unit-tested
        public MefLoginRecognizer() : base( new MefLoginRecognizer.WebRequestCreate() ) { }



        private class WebRequestCreate : IWebRequestCreate
        {
            public WebRequest Create( Uri uri )
            {
                return WebRequest.Create( uri );
            }
        }
#endregion
    }
}
