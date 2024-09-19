using MyClassLibrary.Enum;
using System.Globalization;

namespace SAE2._01.Resources.Converters
{
    public class Ground2Image : IValueConverter
    {
        private static readonly Dictionary<Ground, string> _groundCache = new()
        {
            { Ground.GROUND, "caseground.png" },
            { Ground.RIVER, "caseriver.png" },
            { Ground.TRAP, "casetrap.png" },
            { Ground.DEN, "caseden.png" }
        };

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not Ground ground) return null;
            return _groundCache.TryGetValue(ground, out var image) ? image : null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
