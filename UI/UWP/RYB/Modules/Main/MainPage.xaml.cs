using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using XElement.RedYellowBlue.UI.UWP.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace XElement.RedYellowBlue.UI.UWP
{
#region not unit-tested
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigateTo( NavigationOption.Home );
        }


        private void HamburgerMenu_ItemClick( object sender, ItemClickEventArgs e )
        {
            if ( e.ClickedItem == this._homeItem )
                this.NavigateTo( NavigationOption.Home );
            else if ( e.ClickedItem == this._settingsItem )
                this.NavigateTo( NavigationOption.Settings );
            else /*if ( e.ClickedItem == this._aboutItem )*/
                this.NavigateTo( NavigationOption.About );
        }


        private void NavigateTo( NavigationOption navOption )
        {
            var mainVM = this.DataContext as MainViewModel;
            if ( mainVM != null )
            {
                if ( !mainVM.NavigationModel.IsInitialized )
                {
                    var navManager = SystemNavigationManager.GetForCurrentView();
                    mainVM.NavigationModel.Initialize( this._navigationFrame, navManager );
                }

                mainVM.NavigationModel.NavigateTo( navOption );
            }
        }
    }
#endregion
}
