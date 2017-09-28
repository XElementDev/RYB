using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Network;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer
{
    public class LoginRecognizer : ILoginRecognizer
    {
#region not unit-tested
        public LoginRecognizer()
        {
            this._requesters = null;
        }
#endregion

        internal LoginRecognizer( IRequester requester )
        {
            this._requesters = new IRequester[] { requester };
        }


        private IConfiguration CreateAngleSharpConfig()
        {
            Action<ConfigurationExtensions.LoaderSetup> setupLoader = ( loader ) =>
            {
                loader.IsResourceLoadingEnabled = true;
            };
            IConfiguration config = Configuration.Default 
                .WithDefaultLoader( setupLoader, this._requesters ) 
                .WithJavaScript();
            return config;
        }


        private async Task<IDocument> GetDocumentAsync( Uri routerUri )
        {
            IDocument angleSharpDoc = null;

            var configuration = this.CreateAngleSharpConfig();
            var tab = BrowsingContext.New( configuration );
            var url = new Url( routerUri.AbsoluteUri );
            angleSharpDoc = await tab.OpenAsync( url );

            return angleSharpDoc;
        }


        private static HtmlNode GetHtmlRootNodeFrom( IDocument angleSharpDoc )
        {
            HtmlNode rootNode = null;

            string angleSharpHtml = angleSharpDoc.DocumentElement.OuterHtml;
            var hapDocument = new HtmlDocument();
            hapDocument.LoadHtml( angleSharpHtml );
            rootNode = hapDocument.DocumentNode;

            return rootNode;
        }


        public LoginType /*ILoginRecognizer.*/GetLoginType( Uri routerUri )
        {
            var task = this.GetLoginTypeAsync( routerUri );
            task.Wait();
            return task.Result;
        }

        private async Task<LoginType> GetLoginTypeAsync( Uri routerUri )
        {
            var loginType = default( LoginType );

            var document = await this.GetDocumentAsync( routerUri );
            var rootNode = GetHtmlRootNodeFrom( document );
            var nodes = rootNode.Descendants();
            var passwordFieldNode = nodes.FirstOrDefault( n => n.Id == PASSWORD_FIELD_ID );
            var userFieldNode = nodes.FirstOrDefault( n => n.Id == USERNAME_FIELD_ID );
            var logoNode = nodes.FirstOrDefault( n => n.Id == LOGO_FIELD_ID );

            if ( userFieldNode != null && passwordFieldNode != null )
            {
                loginType = LoginType.USER_BASED;
            }
            else if ( userFieldNode == null && passwordFieldNode != null )
            {
                loginType = LoginType.PASSWORD_BASED;
            }
            else if ( logoNode != null )
            {
                loginType = LoginType.ANONYMOUS;
            }

            return loginType;
        }

#region not unit-tested
        public IEnumerable<string> /*ILoginRecognizer.*/SupportedFritzOsVersions
        {
            get { return new List<string>() { "6.80" }; }
        }
#endregion


        private const string LOGO_FIELD_ID = "avmLogo";

        private const string PASSWORD_FIELD_ID = "uiPass";

        private const string USERNAME_FIELD_ID = "uiViewUser";


        private IEnumerable<IRequester> _requesters;
    }
}
