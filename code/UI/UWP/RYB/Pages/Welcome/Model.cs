using System;
using System.Composition;
using System.Net;
using System.Threading.Tasks;
using XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer;

namespace XElement.RedYellowBlue.UI.UWP.Pages.Welcome
{
#region not unit-tested
    [Shared] [Export]
    internal class Model
    {
        [ImportingConstructor]
        public Model( ModelDependencies dependencies )
        {
            var webRequestFactory = new Model.WebRequestCreate();
            this._dependencies = dependencies;
            this._loginRecognizer = new LoginRecognizer( webRequestFactory );
        }


        public void FinishSetup( string fritzBoxUrl, string username, string password )
        {
            this._dependencies.Config.BoxUrlAsString = fritzBoxUrl;
            this._dependencies.Config.Password = password;
            this._dependencies.Config.Username = username;

            this.SetupFinished.Invoke( null, EventArgs.Empty );
        }


        private LoginType GetLoginType( string fritzBoxUrl )
        {
            Task.Delay( 5000 ).Wait();
            return LoginType.USER_BASED;
            //return this._loginRecognizer.GetLoginType( fritzBoxUrl );
        }

        public Task<LoginType> GetLoginTypeAsync( string fritzBoxUrl )
        {
            return Task.Run<LoginType>( () => { return this.GetLoginType( fritzBoxUrl ); } );
        }


        public event EventHandler SetupFinished;


        private ModelDependencies _dependencies;

        private ILoginRecognizer _loginRecognizer;



        private class WebRequestCreate : IWebRequestCreate
        {
            public WebRequest Create( Uri uri )
            {
                return WebRequest.Create( uri );
            }
        }
    }
#endregion
}
