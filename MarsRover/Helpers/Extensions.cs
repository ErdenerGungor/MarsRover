using System;

namespace MarsRover.Helpers
{
    public static class Extensions
    {
        public static int EnsureMinValue(this int value, int minValue)
        {
            return value > minValue ? value : minValue;
        }

        public static bool IsGreaterThanEqual(this int value, int minValue)
        {
            return value >= minValue;
        }

        public static Int32 ToInt32(this string source, Int32 defaultValue = 0)
        {
            Int32 result = defaultValue;
            Int32.TryParse(source, out result);

            return result;
        }
    }
}
