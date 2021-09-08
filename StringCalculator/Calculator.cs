using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public static class Calculator
    {
        public static int Add(String inputString)
        {
            if (inputString == "")
                return 0;
            var delimiterPattern = GenerateDelimiterPattern(inputString);
            if (Regex.IsMatch(inputString, @"^//"))
                inputString = inputString.Split("\n")[1];
            var listOfNumbers = ConvertStringToIntegerList(inputString, delimiterPattern);
            return AddPositiveIntegers(listOfNumbers);
        }

        private static String GenerateDelimiterPattern(String inputString)
        {
            if (!Regex.IsMatch(inputString, @"(?<=//)")) return "\\n|,";
            var delimiterString = Regex.Match(inputString, @"(?<=//).*(?=\n)").ToString();
            delimiterString = RemoveFirstAndLastSquareBrackets(delimiterString);
            var delimiters = delimiterString.Split("][");
            var escapedDelimiters = delimiters.Select(Regex.Escape).ToList();
            return String.Join("|", escapedDelimiters);
        }

        private static String RemoveFirstAndLastSquareBrackets(String inputString)
        {
            return Regex.IsMatch(inputString, @"^\[.*\]$")
                ? inputString.Substring(1, inputString.Length - 2)
                : inputString;
        }


        private static List<int> ConvertStringToIntegerList(String stringToConvert, String delimiterPattern)
        {
            var numbers = Regex.Split(stringToConvert, @$"{delimiterPattern}");
            return numbers.Select(a => Convert.ToInt32(a)).ToList();
        }

        private static int AddPositiveIntegers(List<int> numbersToAdd)
        {
            int sum = 0;
            List<int> negativeNumbers = new List<int>();
            foreach (var number in numbersToAdd)
            {
                if (number < 0)
                    negativeNumbers.Add(number);
                else
                    sum += (number >= 1000) ? 0 : number;
            }

            if (negativeNumbers.Count > 0)
                throw new FormatException("Negatives not allowed: " + String.Join(", ", negativeNumbers));
            return sum;
        }
    }
}