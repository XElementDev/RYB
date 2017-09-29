using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer
{
    internal class RelevantNodesParser
    {
        public RelevantNodesParser( IEnumerable<HtmlNode> allNodes )
        {
            this.Logo = allNodes.FirstOrDefault( n => n.Id == LOGO_FIELD_ID );
            this.PasswordField = allNodes.FirstOrDefault( n => n.Id == PASSWORD_FIELD_ID );
            this.UserField = allNodes.FirstOrDefault( n => n.Id == USERNAME_FIELD_ID );
        }


        public HtmlNode Logo { get; private set; }


        public HtmlNode PasswordField { get; private set; }


        public HtmlNode UserField { get; private set; }


        private const string LOGO_FIELD_ID = "avmLogo";

        private const string PASSWORD_FIELD_ID = "uiPass";

        private const string USERNAME_FIELD_ID = "uiViewUser";
    }
}
