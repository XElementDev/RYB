using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace XElement.RedYellowBlue.FritzBoxAPI.HttpApi.Aha.v109.ConcreteLayer
{
    //  --> Based on: https://avm.de/fileadmin/user_upload/Global/Service/Schnittstellen/AHA-HTTP-Interface.pdf
    //      taken from: https://avm.de/service/schnittstellen/
    //      Last visited: 2017-02-15
#region not unit-tested
    internal class AhaRequest
    {
        public AhaRequest( Uri fritzBoxUrl, AhaCmd switchcmd, string sid )
        {
            this.Sid = sid;
            this.SwitchCmd = switchcmd;

            var uriBuilder = new UriBuilder( fritzBoxUrl );
            uriBuilder.Path = "webservices/homeautoswitch.lua";
            this._baseUri = uriBuilder.Uri;
        }


        public string Ain { get; set; }


        public WebRequest Create()
        {
            var requestUri = this.CreateUrl();
            return WebRequest.CreateHttp( requestUri );
        }


        private Uri CreateUrl()
        {
            var uriBuilder = new UriBuilder( this._baseUri );
            string ainPart = this.Ain != null ? $"ain={this.Ain}" : null;
            var switchcmdPart = $"switchcmd={this.SwitchCmdAsString}";
            var sidPart = $"sid={this.Sid}";
            var queryParts = new List<string> { ainPart, switchcmdPart, sidPart };
            var query = String.Join( "&", queryParts.Where( str => str != null ).ToList() );
            uriBuilder.Query = query;
            return uriBuilder.Uri;
        }


        public string Param { get; set; }


        public string Sid { get; private set; }


        public AhaCmd SwitchCmd { get; private set; }

        private string SwitchCmdAsString
        {
            get { return this.SwitchCmd.ToString(); }
        }


        private Uri _baseUri;
    }
#endregion
}
