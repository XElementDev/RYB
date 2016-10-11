using System.Collections.Generic;
using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Model.AutoSave
{
#region not unit-tested
    [Shared] [Export]
    internal class DependenciesDTO
    {
        [ImportMany]
        public IEnumerable<IAutoSaveTarget> AutoSaveTargets { get; set; }
    }
#endregion
}
