using System.Composition;
using XElement.RedYellowBlue.UI.UWP.Resources;

namespace XElement.RedYellowBlue.UI.UWP.Modules.About
{
#region not unit-tested
    [Shared] [Export]
    internal class ViewModelDepdenciesDTO
    {
        [Import]
        public SvgSwitch SvgSwitch { get; set; }
    }
#endregion
}
