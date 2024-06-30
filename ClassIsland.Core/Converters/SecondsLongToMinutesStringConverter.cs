using System.Globalization;
using System.Windows.Data;

namespace ClassIsland.Core.Converters;

public class SecondsLongToMinutesStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int v = System.Convert.ToInt32(value) + 59;
        if (v >= 3600)
        {
            return new TimeSpan(0, 0, v).ToString(@"%h\:%m");
        }
        else if (v >= 0)
        {
            return new TimeSpan(0, 0, v).ToString(@"%m");
        }
        else
        {
            return 0;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}
public class SecondsLongToFormatStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int v = System.Convert.ToInt32(value);
        if (v >= 3600)
        {
            return new TimeSpan(0, 0, v).ToString(@"%h\:mm\:ss");
        }
        else if (v >= 60)
        {
            return new TimeSpan(0, 0, v).ToString(@"%m\:ss");
        }
        else if (v >= 0)
        {
            return new TimeSpan(0, 0, v).ToString(@"%s\s");
        }
        else
        {
            return 0;
        }
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}