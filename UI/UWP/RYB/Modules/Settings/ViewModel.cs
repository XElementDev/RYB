using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Settings
{
#region not unit-tested
    [Export]
    internal class ViewModel
    {
        [Import]
        public Settings.Model Model { get; private set; }
    }
#endregion
}
