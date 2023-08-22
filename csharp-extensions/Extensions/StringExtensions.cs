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
    }
}
