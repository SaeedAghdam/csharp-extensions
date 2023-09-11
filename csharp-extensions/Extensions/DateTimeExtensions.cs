namespace CSharpExtensionsLibrary.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Checks if a given year is a leap year or not.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// 
        /*
         A leap year is a year that contains an extra day, February 29th, in order to keep the calendar year synchronized with the astronomical year. 
        The basic rule for determining whether a year is a leap year is as follows:

        1. If the year is evenly divisible by 4, it is a leap year.
        2. However, if the year is also divisible by 100, it is not a leap year unless:
              It is also divisible by 400, in which case it is a leap year.
        */
        public static bool IsLeapYear(this int year) => (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }
}
