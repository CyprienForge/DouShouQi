using System.Globalization;

namespace SAE2._01.Resources.Converters
{
    public class CurrentPlayerOne2Bool : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not int) return null;
            switch (value)
            {
                case 1:
                    return 1;
                case 2:
                    return .5;
                default:
                    return null;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
