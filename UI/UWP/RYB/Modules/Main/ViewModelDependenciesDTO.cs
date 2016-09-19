using System.Composition;
using XElement.RedYellowBlue.UI.UWP.Model;
using DataContextPageTypeMap = XElement.RedYellowBlue.UI.UWP.Model.DataContextPageTypeMap.Model;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Main
{
#region not unit-tested
    [Shared] [Export]
    internal class ViewModelDependenciesDTO
    {
        //  --> import-only
        [Import]
        public Model.AutoSave.Model AutoSaveModel { get; set; }


        [Import]
        public DataContextPageTypeMap DataContextPageTypeMap { get; set; }


        [Import]
        public NavigationModel NavigationModel { get; set; }
    }
#endregion
}
