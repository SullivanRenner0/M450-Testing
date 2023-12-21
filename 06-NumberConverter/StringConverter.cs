using System;

namespace NumberConverters
{
    public class StringConverter : IStringConverter
    {
        private static string[] _singleDigitFragments = { "_", "ein", "zwei", "drei", "vier", "fünf", "sechs", "sieben", "acht", "neun" };

        private static string[] _tenFragments = { "_", "zehn", "zwanzig", "dreissig", "vierzig", "fünfzig", "sechzig", "siebzig", "achzig", "neunzig" };

        private static string[] _positionalFragments = { "_", "_", "hundert", "tausend" };

        /// <summary>
        /// Converts a german numeric string into its numerical value.
        /// This method curently only works with positive integer values <= 9999
        /// and has certain flaws with irregular numeric strings (e.g. values 11, 12).
        /// </summary>
        /// <param name="numericString">String input to be converted.</param>
        /// <returns>Numeric integer representation of string input.</returns>
        public int ConvertToInt(string numericString)
        {
            int value = 0;
            for (int exponent = _positionalFragments.Length - 1; exponent > 1; exponent--)
            {
                if (numericString.Contains(_positionalFragments[exponent]))
                {
                    var parts = numericString.Split(_positionalFragments[exponent]);
                    value += Array.IndexOf(_singleDigitFragments, parts[0]) * (int)Math.Pow(10, exponent);
                    numericString = parts[1];
                }
            }

            for (int i = 1; i < _tenFragments.Length; i++)
            {
                if (numericString.Contains(_tenFragments[i]))
                {
                    value += i * 10;
                    numericString = numericString.Replace(_tenFragments[i], "");
                    break;
                }
            }

            for (int i = 1; i < _singleDigitFragments.Length; i++)
            {
                if (numericString.Contains(_singleDigitFragments[i]))
                {
                    value += i;
                    break;
                }
            }

            return value;
        }
    }
}
