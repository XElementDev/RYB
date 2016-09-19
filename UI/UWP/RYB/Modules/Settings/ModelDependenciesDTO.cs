using System.Composition;
using XElement.RedYellowBlue.UI.UWP.Model;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Settings
{
#region not unit-tested
    [Shared] [Export]
    internal class ModelDependenciesDTO
    {
        [Import]
        public IConfig Config { get; set; }
    }
#endregion
}
