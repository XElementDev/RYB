using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer
{
#region not unit-tested
    public class LoginRecognizer : ILoginRecognizer
    {
        public IEnumerable<string> /*ILoginRecognizer.*/SupportedFritzOsVersions
        {
            get { return new List<string>() { "6.80" }; }
        }
#endregion


        public LoginRecognizer( IWebRequestCreate webRequestFactory )
        {
            this._webRequestFactory = webRequestFactory;
        }


        private static string CreateXPathQuery( string tag, 
                                                string attribute, 
                                                string attributeValue )
        {
            return $"//{tag}[@{attribute}=\"{attributeValue}\"]";
        }


        private async Task<HtmlNode> GetHtmlRootNodeAsync( Uri fritzBoxUrl )
        {
            HtmlNode htmlRootNode = null;

            var request = this._webRequestFactory.Create( fritzBoxUrl );
            var response = await request.GetResponseAsync();
            using ( Stream stream = response.GetResponseStream() )
            {
                var doc = new HtmlDocument();
                doc.Load( stream );
                htmlRootNode = doc.DocumentNode;
            }

            return htmlRootNode;
        }


        public LoginType /*ILoginRecognizer.*/GetLoginType( Uri fritzBoxUrl )
        {
            var getLoginTypeTask = this.GetLoginTypeAsync( fritzBoxUrl );
            getLoginTypeTask.Wait();
            var loginType = getLoginTypeTask.Result;
            return loginType;
        }

        private async Task<LoginType> GetLoginTypeAsync( Uri fritzBoxUrl )
        {
            LoginType loginType = default( LoginType );

            try
            {
                var htmlRootNode = await this.GetHtmlRootNodeAsync( fritzBoxUrl );
                var passwordFieldNode = htmlRootNode.SelectSingleNode( this.XPathQueryForPasswordField );
                var userFieldNode = htmlRootNode.SelectSingleNode( this.XPathQueryForUsernameField );
                var avmLogoNode = htmlRootNode.SelectSingleNode( this.XPathQueryForAvmLogo );
                if ( userFieldNode != null && passwordFieldNode != null )
                {
                    loginType = LoginType.USER_BASED;
                }
                else if ( userFieldNode == null && passwordFieldNode != null )
                {
                    loginType = LoginType.PASSWORD_BASED;
                }
                else if ( avmLogoNode != null )
                {
                    loginType = LoginType.ANONYMOUS;
                }
            }
            catch { }

            return loginType;
        }


        private string XPathQueryForAvmLogo
        {
            get { return CreateXPathQuery( AVM_LOGO_FIELD_TYPE, 
                                           ID_TAG, 
                                           AVM_LOGO_FIELD_ID ); }
        }


        private string XPathQueryForUsernameField
        {
            get { return CreateXPathQuery( USERNAME_FIELD_TYPE, 
                                           ID_TAG, 
                                           USERNAME_FIELD_ID ); }
        }


        private string XPathQueryForPasswordField
        {
            get { return CreateXPathQuery( PASSWORD_FIELD_TYPE, 
                                           ID_TAG, 
                                           PASSWORD_FIELD_ID ); }
        }


        private const string AVM_LOGO_FIELD_ID = "avmLogo";

        private const string AVM_LOGO_FIELD_TYPE = "div";

        private const string ID_TAG = "id";

        private const string PASSWORD_FIELD_ID = "uiPass";

        private const string PASSWORD_FIELD_TYPE = "input";

        private const string USERNAME_FIELD_ID = "uiViewUser";

        private const string USERNAME_FIELD_TYPE = "select";


        private IWebRequestCreate _webRequestFactory;
    }
}
