using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpExtensionsLibrary
{
    public static class StringExtensions
    {
        /// <summary>
        /// The Center extension method is designed to center-align a given string within a specified total length by adding a padding character (default is a space) on both sides of the string. 
        /// </summary>
        /// <param name="str">The input string to be centered.</param>
        /// <param name="length">The total length of the resulting centered string.</param>
        /// <param name="ch">The padding character used to fill the empty spaces. By default, it is a space character.</param>
        /// <returns>string</returns>
        /// <exception cref="ArgumentNullException">If the input string str is null and throws an ArgumentNullException if it is.</exception>
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

        /// <summary>
        /// The Count extension method is designed to count the occurrences of a specified substring within a given string.
        /// </summary>
        /// <param name="str">The input string in which you want to count occurrences.</param>
        /// <param name="value">The substring you want to count within the input string.</param>
        /// <param name="start">The starting index within the input string (inclusive) from which the counting should begin. The default is 0, indicating the start of the input string.</param>
        /// <param name="end">The ending index within the input string (exclusive) at which the counting should stop. The default value of -1 means the counting will continue until the end of the input string.</param>
        /// <returns>int</returns>
        /// <exception cref="ArgumentNullException">If either the input string str or the search substring value is null, and it throws ArgumentNullException if either of them is null.</exception>
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

        /// <summary>
        /// The ConvertCase extension method allows you to convert a given string to different text casing formats based on the specified StringConvertCaseType. 
        /// </summary>
        /// <param name="str">The input string that you want to convert.</param>
        /// <param name="stringConvertCaseType">An enum value representing the desired text casing format.</param>
        /// <returns>string</returns>
        /// <exception cref="ArgumentNullException">If the input string str is null and throws an ArgumentNullException if it is.</exception>
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
            //Converts the string to title case, capitalizing the first letter of each word.
            TitleCase,
            //Converts the string to all lowercase characters.
            LowerCase,
            //Converts the string to all uppercase characters.
            UpperCase,
            //Converts the string to sentence case, capitalizing the first letter of each sentence.
            SentenceCase,
            // Inverts the casing of each letter in the string (lowercase becomes uppercase and vice versa).
            InvertCase,
            //Randomly changes the casing of each letter in the string, producing a mixed-case result.
            RandomCase
        }

        /// <summary>
        /// The IsPalindrome extension method determines whether a given string is a palindrome.
        /// </summary>
        /// <param name="str">The input string to be checked for palindromic properties.</param>
        /// <param name="ignoreSpace">A boolean flag that, when set to true, causes the method </param>
        /// <param name="ignoreCase">A boolean flag that, when set to true, causes the method to perform a case-insensitive comparison when checking for palindromes. The default is false.</param>
        /// <returns>bool</returns>
        /// <exception cref="ArgumentNullException">If the input string str is null and throws an ArgumentNullException if it is.</exception>
        public static bool IsPalindrome(this string str, bool ignoreSpace = false, bool ignoreCase = false)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            var cleanInput = ignoreSpace ? str.Replace(" ", "") : str;
            var reversedInput = new string(cleanInput.Reverse().ToArray());
            return cleanInput.Equals(reversedInput, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture);
        }

        /// <summary>
        /// The IsNumeric extension function serves to determine whether a given string represents a numeric value
        /// </summary>
        /// <param name="str">The input string that you want to check for numeric content.</param>
        /// <returns>bool</returns>
        /// <exception cref="ArgumentNullException">If str is null, it throws an ArgumentNullException with the parameter name "str" to indicate that a valid input string is required.</exception>
        public static bool IsNumeric(this string str) => str != null ? double.TryParse(str, out _) : throw new ArgumentNullException(nameof(str));

        /// <summary>
        /// The In extension function is used to check if a given string exists within an array of string values. It provides a convenient way to determine whether the input string is present among a set of specified values.
        /// </summary>
        /// <param name="str">The input string that you want to check for existence within the array.</param>
        /// <param name="ignoreCase">A boolean flag that, when set to true, performs a case-insensitive comparison. The default is false, which means the comparison is case-sensitive.</param>
        /// <param name="values"> An array of string values among which the presence of the input string is checked.</param>
        /// <returns>bool</returns>
        /// <exception cref="ArgumentNullException">If the input string str is not null. If str is null, it throws an ArgumentNullException with the parameter name "str" to indicate that a valid input string is required.</exception>
        public static bool In(this string str, bool ignoreCase = false, params string[] values)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            return values.Contains(str, ignoreCase ? StringComparer.CurrentCultureIgnoreCase : StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// The RemoveDiacritics extension function is designed to remove diacritic marks (accents) from a given string.
        /// </summary>
        /// <param name="str">The input string from which diacritics are to be removed</param>
        /// <returns>string</returns>
        /// <exception cref="ArgumentNullException">If the input string str is not null. If str is null, it throws an ArgumentNullException with the parameter name "str" to indicate that a valid input string is required.</exception>
        public static string RemoveDiacritics(this string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            var normalizedString = str.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// The GenerateRandomText function generates a random text string of a specified length, with customizable character sets.
        /// </summary>
        /// <param name="length"> The desired length of the random text to be generated.</param>
        /// <param name="includeUpperChars"> A boolean flag indicating whether to include uppercase letters (e.g., A-Z) in the random text. The default is true.</param>
        /// <param name="includeLowerChars"> A boolean flag indicating whether to include lowercase letters (e.g., a-z) in the random text. The default is true.</param>
        /// <param name="includeNumbers">A boolean flag indicating whether to include numbers (e.g., 0-9) in the random text. The default is true.</param>
        /// <param name="includeSpecialChars">A boolean flag indicating whether to include special characters (e.g., !@#$%^&*()_+~|) in the random text. The default is true.</param>
        /// <returns>string</returns>
        public static string GenerateRandomText(
            int length,
            bool includeUpperChars = true,
            bool includeLowerChars = true,
            bool includeNumbers = true,
            bool includeSpecialChars = true)
        {
            var chars = string.Empty;
            var result = string.Empty;
            if(length<=0)
                return result;

            var Upperchars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var lowerChars = "abcdefghijklmnopqrstuvwxyz";
            var numbers = "0123456789";
            var specificChars = "!@#$%^&*()_+~|";

            if (includeUpperChars)
                chars += Upperchars;

            if (includeLowerChars)
                chars += lowerChars;

            if (includeNumbers)
                chars += numbers;

            if (includeSpecialChars)
                chars += specificChars;

            if (string.IsNullOrEmpty(chars))
                return result;

            var random = new Random();
            result = new string(
                Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());

            return result;
        }

        /// <summary>
        /// The SplitByLen extension function divides a given string into smaller chunks of a specified length and returns these chunks as an enumerable collection of strings.
        /// </summary>
        /// <param name="str">The input string that you want to split into smaller chunks.</param>
        /// <param name="chunkSize">The maximum length of each chunk into which the input string should be divided.</param>
        /// <returns>IEnumerable<string></returns>
        /// <exception cref="ArgumentNullException">If the input string str is not null. If str is null, it throws an ArgumentNullException with the parameter name "str" to indicate that a valid input string is required.</exception>
        public static IEnumerable<string> SplitByLen(this string str, int chunkSize)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            var result = new List<string>();

            while (str.Length > 0)
            {
                chunkSize = Math.Min(chunkSize, str.Length);
                var temp = str[..chunkSize];
                result.Add(temp);
                str = str.Remove(0, chunkSize);
            }

            return result;
        }
    }
}
