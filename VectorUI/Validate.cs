using System;

namespace VectorUI
{
    public static class Validate
    {
        public static bool NumberDoubleInput(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
                return false;

            return double.TryParse(text, out _);
        }

        public static bool NumberIntInput(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
                return false;

            return int.TryParse(text, out _);
        }
    }
}