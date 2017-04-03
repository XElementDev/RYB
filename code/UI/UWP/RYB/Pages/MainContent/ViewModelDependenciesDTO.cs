using System.Composition;
using XElement.RedYellowBlue.UI.UWP.Model;

namespace XElement.RedYellowBlue.UI.UWP.Pages.MainContent
{
#region not unit-tested
    [Shared] [Export]
    internal class ViewModelDependenciesDTO
    {
        #region import-only
        [Import]
        public Model.AutoSave.Model AutoSaveModel { get; set; }
        #endregion


        [Import]
        public Model.DataContextPageTypeMap.Model DataContextPageTypeMap { get; set; }


        [Import]
        public Pages.Feedback.ViewModel FeedbackVM { get; set; }


        [Import]
        public NavigationModel NavigationModel { get; set; }
    }
#endregion
}
