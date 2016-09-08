using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109
{
    //  --> Based on: https://avm.de/fileadmin/user_upload/Global/Service/Schnittstellen/AVM_Technical_Note_-_Session_ID.pdf
    //      taken from: https://avm.de/service/schnittstellen/
    //      Last visited: 2016-09-08
#region not unit-tested
    public class Login
    {
        public Login( string fritzBoxUrl, string username )
        {
            var uriBuilder = new UriBuilder( fritzBoxUrl );
            uriBuilder.Path = SESSION_INFO_PAGE;
            this._baseUri = uriBuilder.Uri;

            this._username = username;
        }


        public void Do( string password )
        {
            var sessionInfo = this.GetSessionInfo( this._baseUri );
            if ( sessionInfo.Sid == Login.DEFAULT_SID )
            {
                var hash = this.GenerateHash( sessionInfo.Challenge, password );
                var response = this.GenerateResponseQueryAttribute( sessionInfo.Challenge, hash );
                var query = this.GenerateQuery( response );
                var loginUri = new UriBuilder( this._baseUri ) { Query = query }.Uri;
                this.Sid = this.GetSessionInfo( loginUri ).Sid;
            }
        }


        private string GenerateHash( string challenge, string password )
        {
            var toHash = $"{challenge}-{password}";
            var bytesToHash = Encoding.Unicode.GetBytes( toHash );
            var hashedBytes = MD5.Create().ComputeHash( bytesToHash );
            var stringBuilder = new StringBuilder();
            hashedBytes.Select( b => stringBuilder.Append( b.ToString( "x2" ) ) ).ToList();
            var hash = stringBuilder.ToString();
            return hash;
        }


        private string GenerateQuery( string response )
        {
            return $"username={this._username}&response={response}";
        }


        private string GenerateResponseQueryAttribute( string challenge, string hash )
        {
            return $"{challenge}-{hash}";
        }


        private SessionInfoDTO GetSessionInfo( Uri uri )
        {
            var request = WebRequest.CreateHttp( uri );
            var response = request.GetResponseAsync().Result;
            var serializer = new XmlSerializer( typeof( SessionInfoDTO ) );
            var sessionInfo = (SessionInfoDTO)serializer.Deserialize( response.GetResponseStream() );
            return sessionInfo;
        }


        public string Sid { get; private set; }


        private const string DEFAULT_SID = "0000000000000000";
        private const string SESSION_INFO_PAGE = "login_sid.lua";


        private Uri _baseUri;
        private string _username;
    }
#endregion
}
