using PropertyChanged;
using System.Composition;
using System.Threading.Tasks;

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

            await Task.Delay( 500 );

            this.IsConnectionTestActive = false;
            this.WasConnectionTestPositive = true;

            //var parameters = new ServiceParametersDTO
            //{
            //    Uri = this._dependencies.Config.Uri
            //};
            //var svc = new Service( parameters )
            //{
            //    Password = this._dependencies.Config.Password, 
            //    Username = this._dependencies.Config.Username
            //};
            //svc.IsLoginValid();

            // TODO
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


        public string Url { get; set; }


        public string Username { get; set; }


        public bool? WasConnectionTestPositive { get; private set; }


        private ModelDependenciesDTO _dependencies;
    }
#endregion
}
