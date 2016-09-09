using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Settings
{
#region not unit-tested
    [Export]
    internal class ViewModel
    {
        [ImportingConstructor]
        public ViewModel( Settings.Model model )
        {
            this.Model = model;
        }


        public Settings.Model Model { get; private set; }
    }
#endregion
}
