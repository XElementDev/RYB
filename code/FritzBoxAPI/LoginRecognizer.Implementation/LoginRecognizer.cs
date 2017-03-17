using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using XElement.RedYellowBlue.FritzBoxAPI.HttpApi.SessionId.v20121217;

namespace XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer
{
#region not unit-tested
    public class LoginRecognizer
    {
        public async Task<LoginBase> GetLoginInstanceAsync( Uri fritzBoxUrl )
        {
            LoginBase instance = new AnonymousLogin( fritzBoxUrl );

            var request = this._webRequestFactory.Create( fritzBoxUrl );
            var response = await request.GetResponseAsync();
            using ( Stream stream = response.GetResponseStream() )
            {
                var doc = new HtmlDocument();
                doc.Load( stream );
                var passwordFieldNode = doc.DocumentNode.SelectSingleNode( this.XPathQueryForPasswordField );
                var userFieldNode = doc.DocumentNode.SelectSingleNode( this.XPathQueryForUsernameField );
                if ( userFieldNode != null && passwordFieldNode != null )
                {
                    instance = new UserBasedLogin( fritzBoxUrl, "TODO", "TODO" );
                }
                else if ( userFieldNode == null && passwordFieldNode != null )
                {
                    instance = new PasswordBasedLogin( fritzBoxUrl, "TODO" );
                }
            }

            return instance;
        }


        public IEnumerable<string> SupportedFritzOsVersions
        {
            get { return new List<string>() { "6.80" }; }
        }
#endregion


        public LoginRecognizer( IWebRequestCreate webRequestFactory )
        {
            this._webRequestFactory = webRequestFactory;
        }


        private string CreateXPathQuery( string tag, string attribute, string attributeValue )
        {
            return $"//{tag}[@{attribute}=\"{attributeValue}\"]";
        }


        public LoginBase GetLoginInstance( Uri fritzBoxUrl )
        {
            //  --> https://stackoverflow.com/questions/13211334/how-do-i-wait-until-task-is-finished-in-c
            //  --> TODO: Is this overkill here still needed, now that the tests are fixed?
            var getInstanceTask = this.GetLoginInstanceAsync( fritzBoxUrl );
            LoginBase loginInstance = null;
            var continuation = getInstanceTask.ContinueWith( t => loginInstance = t.Result );
            continuation.Wait();
            return loginInstance;
        }


        private string XPathQueryForUsernameField
        {
            get { return this.CreateXPathQuery( LoginRecognizer.USERNAME_FIELD_TYPE, 
                                                LoginRecognizer.ID_TAG, 
                                                LoginRecognizer.USERNAME_FIELD_ID ); }
        }


        private string XPathQueryForPasswordField
        {
            get { return this.CreateXPathQuery( LoginRecognizer.PASSWORD_FIELD_TYPE, 
                                                LoginRecognizer.ID_TAG, 
                                                LoginRecognizer.PASSWORD_FIELD_ID ); }
        }


        private const string ID_TAG = "id";

        private const string PASSWORD_FIELD_ID = "uiPass";

        private const string PASSWORD_FIELD_TYPE = "input";

        private const string USERNAME_FIELD_ID = "uiViewUser";

        private const string USERNAME_FIELD_TYPE = "select";


        private IWebRequestCreate _webRequestFactory;
    }
}
