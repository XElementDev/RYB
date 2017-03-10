using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Pages.Feedback
{
#region not unit-tested
    [Shared] [Export]
    internal class ViewModel
    {
        [ImportingConstructor]
        public ViewModel( Feedback.Model model )
        {
            this.Model = model;
        }


        public Feedback.Model Model { get; private set; }
    }
#endregion
}
