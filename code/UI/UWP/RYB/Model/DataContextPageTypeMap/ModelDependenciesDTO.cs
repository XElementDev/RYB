using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Model.DataContextPageTypeMap
{
#region not unit-tested
    [Shared] [Export]
    internal class ModelDependenciesDTO
    {
        [Import]
        public Modules.About.ViewModel AboutVM { get; set; }


        [Import]
        public Pages.Feedback.ViewModel FeedbackVM { get; set; }


        [Import]
        public Modules.Home.ViewModel HomeVM { get; set; }


        [Import]
        public Modules.Settings.ViewModel SettingsVM { get; set; }
    }
#endregion
}
