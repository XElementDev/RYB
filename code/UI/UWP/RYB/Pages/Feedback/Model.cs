using Microsoft.Services.Store.Engagement;
using System;
using System.Composition;

namespace XElement.RedYellowBlue.UI.UWP.Pages.Feedback
{
#region not unit-tested
    [Shared] [Export]
    internal class Model
    {
        [ImportingConstructor]
        public Model() { }


        //  --> 2017-03-09, see https://docs.microsoft.com/en-us/windows/uwp/monetize/launch-feedback-hub-from-your-app
        public bool IsFeedbackHubAvailable()
        {
            return StoreServicesFeedbackLauncher.IsSupported();
        }


        public async void LaunchFeedbackHub()
        {
            var launcher = StoreServicesFeedbackLauncher.GetDefault();
            await launcher.LaunchAsync();
        }
    }
#endregion
}
