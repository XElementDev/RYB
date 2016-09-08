using System;
using Windows.UI.Xaml.Controls;
using XElement.RedYellowBlue.UI.UWP.Modules;
using XElement.RedYellowBlue.UI.UWP.Modules.Main;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace XElement.RedYellowBlue.UI.UWP
{
#region not unit-tested
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigateTo( NavigationOptions.Home );
        }


        private void HamburgerMenu_ItemClick( object sender, ItemClickEventArgs e )
        {
            if ( e.ClickedItem == this._homeItem )
                this.NavigateTo( NavigationOptions.Home );
            else if ( e.ClickedItem == this._settingsItem )
                this.NavigateTo( NavigationOptions.Settings );
            else /*if ( e.ClickedItem == this._aboutItem )*/
                this.NavigateTo( NavigationOptions.About );
        }


        private void NavigateTo( NavigationOptions navOptions )
        {
            Type navigateTo = null;

            if ( navOptions == NavigationOptions.Home )
                navigateTo = typeof( HomePage );
            else if ( navOptions == NavigationOptions.Settings )
                navigateTo = typeof( SettingsPage );
            else /*if ( navOptions == NavigationOptions.About )*/
                navigateTo = null; // TODO

            this._navigationFrame.Navigate( navigateTo );
        }
    }
#endregion
}
