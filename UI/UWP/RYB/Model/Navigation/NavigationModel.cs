using System;
using System.Composition;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using XElement.RedYellowBlue.UI.UWP.Modules;

namespace XElement.RedYellowBlue.UI.UWP.Model
{
#region not unit-tested
    [Export]
    internal class NavigationModel
    {
        [ImportingConstructor]
        public NavigationModel() { }


        public void Initialize( Frame frame, SystemNavigationManager navManager )
        {
            this._navigationFrame = frame;
            this._navigationManager = navManager;
            this._navigationManager.BackRequested += this.OnBackRequested;
        }


        public bool IsInitialized
        {
            get { return this._navigationFrame != null && this._navigationManager != null; }
        }


        public void NavigateTo( NavigationOption navOption )
        {
            Type navigateTo = null;

            if ( navOption == NavigationOption.Home )
                navigateTo = typeof( HomePage );
            else if ( navOption == NavigationOption.Settings )
                navigateTo = typeof( SettingsPage );
            else /*if ( navOption == NavigationOptions.About )*/
                navigateTo = null; // TODO

            this._navigationFrame.Navigate( navigateTo );
            this.UpdateGlobalBackButton();
        }


        private void OnBackRequested( object sender, BackRequestedEventArgs e )
        {
            if ( this._navigationFrame.CanGoBack )
            {
                this._navigationFrame.GoBack();
                this.UpdateGlobalBackButton();
                e.Handled = true;
            }
        }


        private void UpdateGlobalBackButton()
        {
            var visibility = AppViewBackButtonVisibility.Collapsed;

            if ( this._navigationFrame.CanGoBack )
            {
                visibility = AppViewBackButtonVisibility.Visible;
            }

            this._navigationManager.AppViewBackButtonVisibility = visibility;
        }


        private Frame _navigationFrame;

        private SystemNavigationManager _navigationManager;
    }
#endregion
}
