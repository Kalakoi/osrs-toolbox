using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace osrs_toolbox
{
    public class DoubleTextBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string Value = value as string;
            if (string.IsNullOrEmpty(Value)) return new SolidColorBrush(Colors.Aquamarine);
            else
            {
                try
                {
                    System.Convert.ToDouble(Value);
                    return new SolidColorBrush(Colors.White);
                }
                catch
                {
                    return new SolidColorBrush(Colors.Red);
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
