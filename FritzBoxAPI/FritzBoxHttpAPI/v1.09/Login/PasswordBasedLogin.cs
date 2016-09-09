using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace XElement.RedYellowBlue.FritzBoxAPI.FritzBoxHttpAPI.v109
{
#region not unit-tested
    public class PasswordBasedLogin : LoginBase
    {
        public PasswordBasedLogin( string fritzBoxUri, string password ) : 
            base( fritzBoxUri )
        {
            this._password = password;
        }


        private string GenerateHash( string challenge )
        {
            var toHash = $"{challenge}-{this._password}";
            var bytesToHash = Encoding.Unicode.GetBytes( toHash );
            var hashedBytes = MD5.Create().ComputeHash( bytesToHash );
            var stringBuilder = new StringBuilder();
            hashedBytes.Select( b => stringBuilder.Append( b.ToString( "x2" ) ) ).ToList();
            var hash = stringBuilder.ToString();
            return hash;
        }


        protected virtual string GenerateQuery( string response )
        {
            return $"response={response}";
        }


        private string GenerateResponseQueryAttribute( string challenge, string hash )
        {
            return $"{challenge}-{hash}";
        }


        protected override string /*LoginBase.*/GetSid()
        {
            string sid = null;

            var sessionInfo = this.GetSessionInfo( this._baseUri );
            if ( sessionInfo.Sid == PasswordBasedLogin.DEFAULT_SID )
            {
                var hash = this.GenerateHash( sessionInfo.Challenge );
                var response = this.GenerateResponseQueryAttribute( sessionInfo.Challenge, hash );
                var query = this.GenerateQuery( response );
                var loginUri = new UriBuilder( this._baseUri ) { Query = query }.Uri;
                sid = this.GetSessionInfo( loginUri ).Sid;
            }

            return sid;
        }


        private string _password;
    }
#endregion
}
