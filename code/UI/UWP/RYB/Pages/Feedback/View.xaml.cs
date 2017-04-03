using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace XElement.RedYellowBlue.UI.UWP.Pages
{
#region not unit-tested
    /// <summary>
    /// A page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FeedbackPage : Page
    {
        public FeedbackPage()
        {
            this.InitializeComponent();
        }


        private Feedback.Model Model { get { return this.ViewModel.Model; } }


        //  --> TODO: Try to solve this in ViewModel (e.g. by using the NavigationManager)
        private void OnPageLoading( FrameworkElement sender, object args )
        {

            this.Model.LaunchFeedbackHub();
        }


        private Feedback.ViewModel ViewModel
        {
            get { return this.DataContext as Feedback.ViewModel; }
        }
    }
#endregion
}
