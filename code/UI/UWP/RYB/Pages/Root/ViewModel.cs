using PropertyChanged;
using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Pages.Root
{
#region not unit-tested
    [Shared] [Export]
    [ImplementPropertyChanged]
    internal class ViewModel
    {
        [ImportingConstructor]
        public ViewModel( Model model, ViewModelDependenciesDTO dependenciesDTO )
        {
            this._dependencies = dependenciesDTO;
            this._model = model;

            this._model.PropertyChanged += ( s, e ) => this.ShowMainContent = true;
            this.ShowMainContent = false;
        }


        public MainViewModel MainVM { get; private set; }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            this.MainVM = this._dependencies.MainVM;
            this.WelcomeVM = this._dependencies.WelcomeVM;
        }


        public bool ShowMainContent { get; private set; }


        public Pages.Welcome.ViewModel WelcomeVM { get; private set; }


        private ViewModelDependenciesDTO _dependencies;

        private Model _model;
    }
#endregion
}
