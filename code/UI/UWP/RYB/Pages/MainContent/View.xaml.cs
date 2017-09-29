using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Collections;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace XElement.RedYellowBlue.UI.UWP.Pages
{
#region not unit-tested
    public sealed partial class MainContentPage : Page
    {
        public MainContentPage()
        {
            this.InitializeComponent();
        }


        private void HamburgerMenu_ItemClick( object sender, ItemClickEventArgs e )
        {
            var clickedHamburgerMenuItem = e.ClickedItem as HamburgerMenuItem;
            this.NavigateTo( clickedHamburgerMenuItem );
        }


        private MainContent.ViewModel MainContentVM
        {
            get { return (MainContent.ViewModel)this.DataContext; }
        }


        private void NavigateTo( HamburgerMenuItem clickedHamburgerMenuItem )
        {
            this.TryInitializeNavigationModel();
            this.MainContentVM.NavigateToCommand.Execute( clickedHamburgerMenuItem );
            this.TryClosePane();
        }


        private void OnDataContextChanged( FrameworkElement sender, DataContextChangedEventArgs args )
        {
            if( this.MainContentVM != null )
            {
                this.NavigateTo( this._home );
                this.TryRemoveFeedbackButton();
            }
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
            var mainContentVM = this.MainContentVM;
            if ( mainContentVM != null )
            {
                if ( !mainContentVM.NavigationModel.IsInitialized )
                {
                    var navManager = SystemNavigationManager.GetForCurrentView();
                    mainContentVM.NavigationModel.Initialize( this._navigationFrame, navManager );
                }
            }
        }


        private void TryRemoveFeedbackButton()
        {
            if ( !this.MainContentVM.FeedbackVM.Model.IsFeedbackHubAvailable() )
            {
                var optionItemsSource = this._hamburgerMenu.OptionsItemsSource;
                var optionItems = optionItemsSource as IList;
                optionItems.Remove( this._feedbackOption );
            }
        }
    }
#endregion
}
