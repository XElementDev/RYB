using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace XElement.RedYellowBlue.UI.UWP
{
#region not unit-tested
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        private void HamburgerMenu_ItemClick( object sender, ItemClickEventArgs e )
        {
            var clickedHamburgerMenuItem = e.ClickedItem as HamburgerMenuItem;
            this.MainVM.Header = clickedHamburgerMenuItem.Label;
            this.NavigateTo( clickedHamburgerMenuItem.TargetPageType );
        }


        private MainViewModel MainVM { get { return (MainViewModel)this.DataContext; } }


        private void NavigateTo( Type targetPageType )
        {
            var mainVM = this.MainVM;
            if ( mainVM != null )
            {
                if ( !mainVM.NavigationModel.IsInitialized )
                {
                    var navManager = SystemNavigationManager.GetForCurrentView();
                    mainVM.NavigationModel.Initialize( this._navigationFrame, navManager );
                }

                mainVM.NavigationModel.NavigateTo( targetPageType );
            }
        }
    }
#endregion
}
