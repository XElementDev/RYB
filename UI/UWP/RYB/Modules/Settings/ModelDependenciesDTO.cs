using System.Composition;
using XElement.RedYellowBlue.UI.UWP.Model;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Settings
{
#region not unit-tested
    [Export]
    internal class ModelDependenciesDTO
    {
        [Import]
        public Config Config { get; set; }
    }
#endregion
}
