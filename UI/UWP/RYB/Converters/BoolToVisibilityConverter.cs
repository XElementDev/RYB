using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace XElement.RedYellowBlue.UI.UWP.Converters
{
#region not unit-tested
    public class BoolToVisibilityConverter : IValueConverter
    {
        public BoolToVisibilityConverter()
        {
            this.FalseValue = Visibility.Collapsed;
            this.NullValue = Visibility.Collapsed;
            this.TrueValue = Visibility.Visible;
        }


        public object Convert( object value, Type targetType, object parameter, string language )
        {
            var valueAsBool = value as bool?;

            if ( valueAsBool == false ) return this.FalseValue;
            else if ( valueAsBool == null ) return this.NullValue;
            else /*if ( valueAsBool == true )*/ return this.TrueValue;
        }


        public object ConvertBack( object value, Type targetType, object parameter, string language )
        {
            throw new NotImplementedException();
        }


        public Visibility FalseValue { get; set; }


        public Visibility NullValue { get; set; }


        public Visibility TrueValue { get; set; }
    }
#endregion
}
