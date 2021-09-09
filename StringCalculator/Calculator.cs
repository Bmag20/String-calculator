using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public static class Calculator
    {
        private const string DefaultDelimiter = "\\n|,";

        public static int Add(string inputString)
        {
            if (inputString == "") return 0;
            string delimiterPattern;
            if (IsSupportOtherDelimiter(inputString))
            {
                delimiterPattern = PatternGenerator.GenerateDelimiterPattern(inputString);
                // Remove the initial part where the delimiters are defined from the input string
                inputString = inputString.Split("\n")[1];
            }
            else
                delimiterPattern = DefaultDelimiter;

            var listOfNumbers = ConvertStringToIntegerList(inputString, delimiterPattern);
            return AddPositiveIntegers(listOfNumbers);
        }

        private static bool IsSupportOtherDelimiter(string inputString)
        {
            return Regex.IsMatch(inputString, @"^//");
        }

        private static List<int> ConvertStringToIntegerList(string stringToConvert, string delimiterPattern)
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
                throw new FormatException("Negatives not allowed: " + string.Join(", ", negativeNumbers));
            return sum;
        }
    }
}