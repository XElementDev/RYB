using System.Collections.Generic;
using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Model.AutoSave
{
#region not unit-tested
    [Shared] [Export]
    internal class DependenciesDTO
    {
        [Import]
        public AppStateManager.Model AppStateManager { get; set; }


        [ImportMany]
        public IEnumerable<IAutoSaveTarget> AutoSaveTargets { get; set; }
    }
#endregion
}
