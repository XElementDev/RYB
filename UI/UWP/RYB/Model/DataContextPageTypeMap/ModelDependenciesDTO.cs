using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Model.DataContextPageTypeMap
{
#region not unit-tested
    [Export]
    internal class ModelDependenciesDTO
    {
        [Import]
        public Modules.Settings.ViewModel SettingsVM { get; set; }
    }
#endregion
}
