using System.Globalization;
using MyClassLibrary.Essentials;

namespace SAE2._01.Resources.Converters
{
    public class Animal2Image : IValueConverter
    {
        private static readonly Dictionary<(int player, int animal), string> _animalCache = new()
        {
            { (1, 1), "pawnbluerat.png" },
            { (1, 2), "pawnbluecat.png" },
            { (1, 3), "pawnbluedog.png" },
            { (1, 4), "pawnbluewolf.png" },
            { (1, 5), "pawnbluepanther.png" },
            { (1, 6), "pawnbluetiger.png" },
            { (1, 7), "pawnbluelion.png" },
            { (1, 8), "pawnblueelephant.png" },
            { (2, 1), "pawnredrat.png" },
            { (2, 2), "pawnredcat.png" },
            { (2, 3), "pawnreddog.png" },
            { (2, 4), "pawnredwolf.png" },
            { (2, 5), "pawnredpanther.png" },
            { (2, 6), "pawnredtiger.png" },
            { (2, 7), "pawnredlion.png" },
            { (2, 8), "pawnredelephant.png" }
        };

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not Animal animal) return null;
            return _animalCache.TryGetValue((animal.PlayerOwner.Id, animal.Strength), out var image) ? image : null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
