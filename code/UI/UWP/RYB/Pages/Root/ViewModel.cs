using PropertyChanged;
using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Pages.Root
{
#region not unit-tested
    [Shared] [Export]
    [AddINotifyPropertyChangedInterface]
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


        public MainContent.ViewModel MainContentVM { get; private set; }


        [OnImportsSatisfied]
        internal void OnImportsSatisfied()
        {
            this.MainContentVM = this._dependencies.MainContentVM;
            this.WelcomeVM = this._dependencies.WelcomeVM;
        }


        public bool ShowMainContent { get; private set; }


        public Pages.Welcome.ViewModel WelcomeVM { get; private set; }


        private ViewModelDependenciesDTO _dependencies;

        private Model _model;
    }
#endregion
}
