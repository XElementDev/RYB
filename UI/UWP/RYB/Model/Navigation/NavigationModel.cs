using GalaSoft.MvvmLight;
using System;
using System.Composition;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace XElement.RedYellowBlue.UI.UWP.Model
{
#region not unit-tested
    [Export]
    internal class NavigationModel : ViewModelBase
    {
        [ImportingConstructor]
        public NavigationModel() { }


        public Type CurrentTarget { get { return this._navigationFrame.Content.GetType(); } }


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


        public void NavigateTo( Type targetPageType )
        {
            this._navigationFrame.Navigate( targetPageType );
            this.UpdateGlobalBackButton();
            this.RaisePropertyChanged( nameof( this.CurrentTarget ) );
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
            //var visibility = AppViewBackButtonVisibility.Collapsed;

            //if ( this._navigationFrame.CanGoBack )
            //{
            //    visibility = AppViewBackButtonVisibility.Visible;
            //}

            //this._navigationManager.AppViewBackButtonVisibility = visibility;
        }


        private Frame _navigationFrame;

        private SystemNavigationManager _navigationManager;
    }
#endregion
}
