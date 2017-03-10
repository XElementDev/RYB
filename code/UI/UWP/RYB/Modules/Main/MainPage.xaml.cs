using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Collections;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml;
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
            this.NavigateTo( clickedHamburgerMenuItem );
        }


        private MainViewModel MainVM { get { return (MainViewModel)this.DataContext; } }


        private void NavigateTo( HamburgerMenuItem clickedHamburgerMenuItem )
        {
            this.TryInitializeNavigationModel();
            this.MainVM.NavigateToCommand.Execute( clickedHamburgerMenuItem );
            this.TryClosePane();
        }


        private void OnDataContextChanged( FrameworkElement sender, DataContextChangedEventArgs args )
        {
            this.NavigateTo( this._home );
            this.TryRemoveFeedbackButton();
        }


        private void TryClosePane()
        {
            var visualStateGroups = VisualStateManager.GetVisualStateGroups( this._hamburgerMenu );
            var group = visualStateGroups.First();
            if ( group.CurrentState.Name != "Desktop" )
            {
                this._hamburgerMenu.IsPaneOpen = false;
            }
        }


        private void TryInitializeNavigationModel()
        {
            var mainVM = this.MainVM;
            if ( mainVM != null )
            {
                if ( !mainVM.NavigationModel.IsInitialized )
                {
                    var navManager = SystemNavigationManager.GetForCurrentView();
                    mainVM.NavigationModel.Initialize( this._navigationFrame, navManager );
                }
            }
        }


        private void TryRemoveFeedbackButton()
        {
            if ( !this.MainVM.FeedbackVM.Model.IsFeedbackHubAvailable() )
            {
                var optionItemsSource = this._hamburgerMenu.OptionsItemsSource;
                var optionItems = optionItemsSource as IList;
                optionItems.Remove( this._feedbackOption );
            }
        }
    }
#endregion
}
