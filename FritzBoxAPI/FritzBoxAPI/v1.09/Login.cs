using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace XElement.RedYellowBlue.FritzBoxAPI.v109
{
#region not unit-tested
    public class Login
    {
        public Login( string fritzBoxUrl, string username )
        {
            this._uriBuilder = new UriBuilder( fritzBoxUrl );
            this._uriBuilder.Path = SESSION_INFO_PAGE;
            this._username = username;
        }


        public void Do( string password )
        {
            var sessionInfo = this.GetSessionInfo();
            if ( sessionInfo.Sid == Login.DEFAULT_SID )
            {
                var hash = this.GenerateHash( sessionInfo.Challenge, password );
                var response = this.GenerateResponseQueryAttribute( sessionInfo.Challenge, hash );
                this._uriBuilder.Query = this.GenerateQuery( response );
                var request = WebRequest.CreateHttp( this._uriBuilder.Uri );
                this.Sid = this.GetSessionInfo().Sid;
            }
        }


        private string GenerateHash( string challenge, string password )
        {
            var toHash = $"{challenge}-{password}";
            var bytesToHash = Encoding.UTF8.GetBytes( toHash );
            var hashedBytes = MD5.Create().ComputeHash( bytesToHash );
            var stringBuilder = new StringBuilder();
            hashedBytes.Select( b => stringBuilder.Append( b.ToString( "x2" ) ) );
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


        private SessionInfoDTO GetSessionInfo()
        {
            var request = WebRequest.CreateHttp( this._uriBuilder.Uri );
            var response = request.GetResponseAsync().Result;
            var serializer = new XmlSerializer( typeof( SessionInfoDTO ) );
            var sessionInfo = (SessionInfoDTO)serializer.Deserialize( response.GetResponseStream() );
            return sessionInfo;
        }


        public string Sid { get; private set; }


        private const string DEFAULT_SID = "0000000000000000";
        private const string SESSION_INFO_PAGE = "login_sid.lua";


        private UriBuilder _uriBuilder;
        private string _username;
    }
#endregion
}
