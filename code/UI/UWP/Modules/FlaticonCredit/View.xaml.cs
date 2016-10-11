using Mntone.SvgForXaml;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace XElement.RedYellowBlue.UI.UWP.Modules
{
#region not unit-tested
    public sealed partial class FlaticonCreditUC : UserControl
    {
        public FlaticonCreditUC()
        {
            this.InitializeComponent();
        }


        public string AuthorName
        {
            get { return (string)this.GetValue( AuthorNameProperty ); }
            set { this.SetValue( AuthorNameProperty, value ); }
        }

        public static readonly DependencyProperty AuthorNameProperty = 
            DependencyProperty.Register( nameof( AuthorName ), typeof( string ), 
                                         typeof( FlaticonCreditUC ), 
                                         new PropertyMetadata( String.Empty ) );


        public Uri AuthorUri
        {
            get { return (Uri)this.GetValue( AuthorUriProperty ); }
            set { this.SetValue( AuthorUriProperty, value ); }
        }

        public static readonly DependencyProperty AuthorUriProperty =
            DependencyProperty.Register( nameof( AuthorUri ), typeof( Uri ), 
                                         typeof( FlaticonCreditUC ), 
                                         new PropertyMetadata( null ) );


        //public ImageSource IconImageSource
        //{
        //    get { return (ImageSource)this.GetValue( IconImageSourceProperty ); }
        //    set { this.SetValue( IconImageSourceProperty, value ); }
        //}

        //public static readonly DependencyProperty IconImageSourceProperty =
        //    DependencyProperty.Register( nameof( IconImageSource ), typeof( ImageSource ), 
        //                                 typeof( FlaticonCreditUC ), 
        //                                 new PropertyMetadata( null ) );


        public SvgDocument SvgImage
        {
            get { return (SvgDocument)this.GetValue( SvgImageProperty ); }
            set { this.SetValue( SvgImageProperty, value ); }
        }

        public static readonly DependencyProperty SvgImageProperty = 
            DependencyProperty.Register( nameof( SvgImage ), typeof( SvgDocument ), 
                                         typeof( FlaticonCreditUC ), new PropertyMetadata( null ) );
    }
#endregion
}
