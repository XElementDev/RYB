using System;

namespace XElement.RedYellowBlue.FritzBoxAPI.HttpApi.SessionId.v20121217
{
#region not unit-tested
    public class UserBasedLogin : PasswordBasedLogin
    {
        public UserBasedLogin( Uri fritzBoxUri, string username, string password ) 
            : base( fritzBoxUri, password )
        {
            this._username = username;
        }


        protected override string /*PasswordBasedLogin*/GenerateQuery( string response )
        {
            return $"username={this._username}&{base.GenerateQuery( response )}";
        }


        private string _username;
    }
#endregion
}
