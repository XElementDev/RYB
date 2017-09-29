using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Pages.Root
{
#region not unit-tested
    [Shared] [Export]
    internal class ModelDependencies
    {
        [Import]
        public Welcome.Model WelcomeModel { get; set; }
    }
#endregion
}
