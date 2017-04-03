using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Pages.Root
{
#region not unit-tested
    [Shared] [Export]
    internal class Model : ViewModelBase, INotifyPropertyChanged
    {
        [ImportingConstructor]
        public Model( ModelDependencies dependencies )
        {
            this._dependencies = dependencies;
            this.SetupFinished = false;
        }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            this._dependencies.WelcomeModel.SetupFinished += ( s, e ) => this.SetupFinished = true;
        }


        private bool _setupFinished;

        public bool SetupFinished
        {
            get { return this._setupFinished; }
            private set
            {
                this._setupFinished = value;
                this.RaisePropertyChanged( nameof( SetupFinished ) );
            }
        }


        private ModelDependencies _dependencies;
    }
#endregion
}
