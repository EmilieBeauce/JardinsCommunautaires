using System;
using System.Globalization;
using System.Windows.Data;

namespace TP2_14E_A2022.Pages;

public class BoolToTooltipConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool estPaye)
        {
            return estPaye ? null : "Cet usager n'a pas encore payé";
        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
