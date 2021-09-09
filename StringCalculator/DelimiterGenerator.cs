using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    static class PatternGenerator 
    {
        public static string GenerateDelimiterPattern(string inputString)
        {
            // Delimiters are defined between // and \n
            var delimiterString = Regex.Match(inputString, @"(?<=//).*(?=\n)").ToString();
            delimiterString = RemoveFirstAndLastSquareBrackets(delimiterString);
            var delimiters = delimiterString.Split("][");
            // Some delimiters need to be preceded with \ (escaped)
            var escapedDelimiters = delimiters.Select(Regex.Escape).ToList();
            return string.Join("|", escapedDelimiters);
        }

        private static string RemoveFirstAndLastSquareBrackets(string inputString)
        {
            return (InsideSquareBrackets(inputString))
                ? inputString.Substring(1, inputString.Length - 2)
                : inputString;
        }

        private static bool InsideSquareBrackets(string inputString)
        {
            return Regex.IsMatch(inputString, @"^\[.*\]$");
        }
    }
}