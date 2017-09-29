using System;
using Windows.UI.Xaml.Data;

namespace XElement.RedYellowBlue.UI.UWP.Pages.Welcome
{
#region not unit-tested
    public class BoolToDoubleConverter : IValueConverter
    {
        public BoolToDoubleConverter()
        {
            this.FalseValue = 0D;
            this.NullValue = 0D;
            this.TrueValue = 1D;
        }


        public object Convert( object value, Type targetType, object parameter, string language )
        {
            var valueAsBool = value as bool?;
            return this.Convert( valueAsBool );
        }

        private double Convert( bool? isTrue )
        {
            if ( isTrue == false ) return this.FalseValue;
            else if ( isTrue == null ) return this.NullValue;
            else /*if ( isTrue == true ) */ return this.TrueValue;
        }


        public object ConvertBack( object value, Type targetType, object parameter, string language )
        {
            throw new NotImplementedException();
        }


        public double FalseValue { get; set; }


        public double NullValue { get; set; }


        public double TrueValue { get; set; }
    }
#endregion
}
