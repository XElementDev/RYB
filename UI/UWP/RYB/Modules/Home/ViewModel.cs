using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Modules.Home
{
#region not unit-tested
    [Shared] [Export]
    internal class ViewModel
    {
        [ImportingConstructor]
        public ViewModel( Home.Model model )
        {
            this.Model = model;
        }


        public Home.Model Model { get; private set; }
    }
#endregion
}
