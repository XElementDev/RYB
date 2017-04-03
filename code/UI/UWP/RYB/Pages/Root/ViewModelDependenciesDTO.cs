using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Pages.Root
{
#region not unit-tested
    [Shared] [Export]
    internal class ViewModelDependenciesDTO
    {
        [ImportingConstructor]
        public ViewModelDependenciesDTO() { }


        [Import]
        public MainViewModel MainVM { get; set; }


        [Import]
        public Pages.Welcome.ViewModel WelcomeVM { get; set; }
    }
#endregion
}
