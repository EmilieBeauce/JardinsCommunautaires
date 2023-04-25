using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

public class BoolToBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool estPaye = (bool)value;
        return estPaye ? new SolidColorBrush(Colors.Transparent) : new SolidColorBrush(Colors.Red);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}