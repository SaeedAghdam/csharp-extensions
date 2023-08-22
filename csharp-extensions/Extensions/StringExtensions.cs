using System.Globalization;
using System.Text.RegularExpressions;

namespace csharp_extensions.Extensions
{
    public static class StringExtensions
    {
        public static string Center(this string str, int length, char ch = ' ')
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            var paddingSize = length - str.Length;
            if (paddingSize <= 0)
                return str;

            var leftPadSize = (int)Math.Ceiling(paddingSize / 2.0);
            str = str.PadLeft(leftPadSize + str.Length, ch).PadRight(length, ch);
            return str;
        }

        public static int Count(this string str, string value, int start = 0, int end = -1)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (string.IsNullOrWhiteSpace(str) || string.IsNullOrWhiteSpace(value))
                return 0;

            if (end == -1)
                end = str.Length;

            var newStr = str.Substring(start, end);

            if (!newStr.Contains(value))
                return 0;

            return newStr.Split(value).Length - 1;

        }

        public static string ConvertCase(this string str, StringConvertCaseType stringConvertCaseType)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            switch (stringConvertCaseType)
            {
                case StringConvertCaseType.TitleCase:
                    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
                case StringConvertCaseType.LowerCase:
                    return str.ToLower();
                case StringConvertCaseType.UpperCase:
                    return str.ToUpper();
                case StringConvertCaseType.SentenceCase:
                    var regex = new Regex(@"(^[a-z])|\.\s+(.)", RegexOptions.ExplicitCapture);
                    return regex.Replace(str.ToLower(), s => s.Value.ToUpper());
                case StringConvertCaseType.InvertCase:
                    return new string(str.Select(c => char.IsLetter(c) ? (char.IsUpper(c) ?
                       char.ToLower(c) : char.ToUpper(c)) : c).ToArray());
                case StringConvertCaseType.RandomCase:
                    var random = new Random();
                    return new string(str.Select(c => char.IsLetter(c) ? (random.Next(2) == 1 ?
                      char.ToLower(c) : char.ToUpper(c)) : c).ToArray());
                default:
                    return str;
            }
        }


        public enum StringConvertCaseType
        {
            TitleCase,
            LowerCase,
            UpperCase,
            SentenceCase,
            InvertCase,
            RandomCase
        }
    }
}
