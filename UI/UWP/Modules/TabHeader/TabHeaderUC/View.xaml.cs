using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace XElement.RedYellowBlue.UI.UWP.Modules
{
#region not unit-tested
    public sealed partial class TabHeaderUC : UserControl
    {
        public TabHeaderUC()
        {
            this.InitializeComponent();
        }


        public string Glyph
        {
            get { return (string)this.GetValue( TabHeaderUC.GlyphProperty ); }
            set { this.SetValue( TabHeaderUC.GlyphProperty, value ); }
        }

        public static readonly DependencyProperty GlyphProperty = 
            DependencyProperty.Register( nameof( Glyph ), typeof( string ), 
                                         typeof( TabHeaderUC ), 
                                         new PropertyMetadata( String.Empty ) );


        public string Label
        {
            get { return (string)this.GetValue( TabHeaderUC.LabelProperty ); }
            set { this.SetValue( TabHeaderUC.LabelProperty, value ); }
        }

        public static readonly DependencyProperty LabelProperty = 
            DependencyProperty.Register( nameof( Label ), typeof( string ), typeof( TabHeaderUC ), 
                                         new PropertyMetadata( String.Empty ) );
    }
#endregion
}
