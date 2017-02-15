using System;
using System.Net;
using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.HttpApi.SessionId.v20121217
{
    //  --> Based on: https://avm.de/fileadmin/user_upload/Global/Service/Schnittstellen/AVM_Technical_Note_-_Session_ID.pdf
    //      taken from: https://avm.de/service/schnittstellen/
    //      Last visited: 2017-02-15
#region not unit-tested
    public abstract class LoginBase
    {
        public LoginBase( Uri fritzBoxUrl )
        {
            var uriBuilder = new UriBuilder( fritzBoxUrl );
            uriBuilder.Path = SESSION_INFO_PAGE;
            this._baseUri = uriBuilder.Uri;
        }


        public void Do()
        {
            string sid = null;

            try
            {
                sid = this.GetSid();
            }
            catch { }

            if ( (sid ?? LoginBase.DEFAULT_SID) == LoginBase.DEFAULT_SID )
            {
                throw new Exception( "Login failed." );
            }

            this.Sid = sid;
        }


        protected SessionInfoDTO GetSessionInfo( Uri uri )
        {
            var request = WebRequest.CreateHttp( uri );
            var response = request.GetResponseAsync().Result;
            var serializer = new XmlSerializer( typeof( SessionInfoDTO ) );
            var sessionInfo = (SessionInfoDTO)serializer.Deserialize( response.GetResponseStream() );
            return sessionInfo;
        }


        protected abstract string GetSid();


        public string Sid { get; private set; }


        protected const string DEFAULT_SID = "0000000000000000";

        private const string SESSION_INFO_PAGE = "login_sid.lua";


        protected Uri _baseUri;
    }
#endregion
}
