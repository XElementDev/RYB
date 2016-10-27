using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace XElement.RedYellowBlue.UI.UWP.Modules
{
#region not unit-tested
    public sealed partial class GitHubLinkUC : UserControl
    {
        public GitHubLinkUC()
        {
            this.DataContext = new GitHubLink.ViewModel();
            this.InitializeComponent();
        }


        public Uri GitHubProjectUri
        {
            get { return (Uri)this.GetValue( GitHubProjectUriProperty ); }
            set { this.SetValue( GitHubProjectUriProperty, value ); }
        }

        public static readonly DependencyProperty GitHubProjectUriProperty = 
            DependencyProperty.Register( nameof( GitHubProjectUri ), typeof( Uri ), 
                                         typeof( GitHubLinkUC ), 
                                         new PropertyMetadata( null ) );
    }
#endregion
}
