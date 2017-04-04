using System;
using System.Composition;
using System.Threading.Tasks;
using XElement.RedYellowBlue.FritzBoxAPI.LoginRecognizer;

namespace XElement.RedYellowBlue.UI.UWP.Pages.Welcome
{
    [Shared] [Export]
    internal class Model
    {
#region not unit-tested
        [ImportingConstructor]
#endregion
        public Model( ModelDependencies dependencies )
        {
            this._dependencies = dependencies;
        }



        public void FinishSetup( string boxUrlAsString, string username, string password )
        {
            this._dependencies.Config.BoxUrlAsString = boxUrlAsString;
            this._dependencies.Config.Password = password;
            this._dependencies.Config.Username = username;

            if ( this.SetupFinished != null )
            {
                this.SetupFinished.Invoke( null, EventArgs.Empty );
            }
        }


        private LoginType GetLoginType( string boxUrlAsString )
        {
            var loginType = default( LoginType );

            try
            {
                var fritzBoxUrl = new UriBuilder( boxUrlAsString ).Uri; ;
                loginType = this._dependencies.LoginRecognizer.GetLoginType( fritzBoxUrl );
            }
            catch { }

            return loginType;
        }

        public Task<LoginType> GetLoginTypeAsync( string boxUrlAsString )
        {
            return Task.Run<LoginType>( () => { return this.GetLoginType( boxUrlAsString ); } );
        }


        public event EventHandler SetupFinished;


        private ModelDependencies _dependencies;
    }
}
