﻿using PropertyChanged;
using System.Composition;
using XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Settings
{
#region not unit-tested
    [Export]
    [ImplementPropertyChanged]
    internal class Model
    {
        [ImportingConstructor]
        public Model( ModelDependenciesDTO dependencies )
        {
            this.IsConnectionTestActive = false;
            this.WasConnectionTestPositive = null;

            this._dependencies = dependencies;
        }


        public async void CheckLogin()
        {
            this.WasConnectionTestPositive = null;
            this.IsConnectionTestActive = true;


            var isLoginValid = await this.CreateHttpService().IsLoginValidAsync();

            if ( isLoginValid )
            {
                this.PersistToNextLayer();
            }

            this.IsConnectionTestActive = false;
            this.WasConnectionTestPositive = isLoginValid;
        }


        private IHttpService CreateHttpService()
        {
            var parameters = new HttpServiceParametersDTO
            {
                Uri = this.Url
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


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            this.Password = this._dependencies.Config.Password;
            this.Url = this._dependencies.Config.Uri;
            this.Username = this._dependencies.Config.Username;
        }


        public string Password { get; set; }


        private void PersistToNextLayer()
        {
            this._dependencies.Config.Password = this.Password;
            this._dependencies.Config.Uri = this.Url;
            this._dependencies.Config.Username = this.Username;
        }


        public string Url { get; set; }


        public string Username { get; set; }


        public bool? WasConnectionTestPositive { get; private set; }


        private ModelDependenciesDTO _dependencies;
    }
#endregion
}
