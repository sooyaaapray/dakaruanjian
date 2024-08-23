using System;
using System.Globalization;
using System.Windows.Data;


namespace ClockIn.Client.Controls
{
    public class CheckConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return false;
            }
            string checkValue = value.ToString();
            string targetValue = parameter.ToString();
            bool r = checkValue.Equals(targetValue);
            return r;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return null;
            }

            if ((bool)value)
            {
                return parameter.ToString();
            }
            return null;
        }
    }
}
