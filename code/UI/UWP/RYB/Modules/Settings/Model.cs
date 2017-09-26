using PropertyChanged;
using System.Composition;
using XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Settings
{
#region not unit-tested
    [Shared] [Export]
    [AddINotifyPropertyChangedInterface]
    internal class Model
    {
        [ImportingConstructor]
        public Model( ModelDependenciesDTO dependencies )
        {
            this.IsConnectionTestActive = false;
            this.WasConnectionTestPositive = null;

            this._dependencies = dependencies;
        }


        public string BoxUrlAsString
        {
            get { return this._dependencies.Config.BoxUrlAsString; }
            set { this._dependencies.Config.BoxUrlAsString = value; }
        }


        public async void CheckLogin()
        {
            this.WasConnectionTestPositive = null;
            this.IsConnectionTestActive = true;

            var isLoginValid = await this.CreateHttpService().IsLoginValidAsync();

            this.IsConnectionTestActive = false;
            this.WasConnectionTestPositive = isLoginValid;
        }


        private IHttpService CreateHttpService()
        {
            var parameters = new HttpServiceParametersDTO
            {
                BoxUrl = this._dependencies.Config.BoxUrl
            };
            var optional = new OptionalHttpServiceParametersDTO
            {
                Password = this.Password, 
                Username = this.Username
            };
            var svc = new HttpService( parameters, optional );
            return svc;
        }


        public bool IsConnectionTestActive { get; private set; }


        public string Password
        {
            get { return this._dependencies.Config.Password; }
            set { this._dependencies.Config.Password = value; }
        }


        public string Username
        {
            get { return this._dependencies.Config.Username; }
            set { this._dependencies.Config.Username = value; }
        }


        public bool? WasConnectionTestPositive { get; private set; }


        private ModelDependenciesDTO _dependencies;
    }
#endregion
}
