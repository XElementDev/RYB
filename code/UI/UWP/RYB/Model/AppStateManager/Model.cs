using System.Composition;
using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace XElement.RedYellowBlue.UI.UWP.Model.AppStateManager
{
#region not unit-tested
    internal delegate void NotificationEventHandler();


    [Shared] [Export]
    internal class Model
    {
        [ImportingConstructor]
        public Model( DependenciesDTO dependencies )
        {
            Application.Current.Suspending += this.OnAppSuspending;
        }


        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnAppSuspending( object sender, SuspendingEventArgs e )
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            //  --> Save application state and stop any background activity
            this.OnSuspending.Invoke();

            deferral.Complete();
        }


        public event NotificationEventHandler OnSuspending;
    }
#endregion
}
