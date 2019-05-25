using System.Globalization;

namespace BuildingVitals.Common.Helpers
{
    /// <summary>
    /// The number extensions class.
    /// </summary>
    public static class NumberExtensions
    {
        /// <summary>
        /// Parse the double value from string using the current culture.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Double value.</returns>
        public static double ParseDoubleValue(string value)
        {
            double output;
            return double.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out output) ?
                output : double.Parse(value.Replace(",", "."), CultureInfo.InvariantCulture);
        }
    }
}
