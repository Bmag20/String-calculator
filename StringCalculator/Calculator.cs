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
            if (Regex.IsMatch(inputString, @"//.\n\d(.\d)+"))
            {
                var inputAfterNewLine = inputString.Split("\n")[1];
                var listOfNumbers = ConvertStringToIntegerList(inputAfterNewLine, Regex.Escape(inputString[2].ToString()));
                return AddListOfPositiveNumbers(listOfNumbers);
            }

            if (Regex.IsMatch(inputString, @"(?<=//\[)"))
            {
                var delimiterString = Regex.Match(inputString, @"(?<=\[).*(?=\])").ToString();
                var delimiters = delimiterString.Split("][");
                var escapedDelimiters = delimiters.Select(Regex.Escape).ToList();
                var regExPattern = String.Join("|", escapedDelimiters);
                var inputAfterNewLine = inputString.Split("\n")[1];
                var listOfNumbers = ConvertStringToIntegerList(inputAfterNewLine, regExPattern);
                return AddListOfPositiveNumbers(listOfNumbers);
            }
            else
            {
                var listOfNumbers = ConvertStringToIntegerList(inputString, "\\n|,");
                return AddListOfPositiveNumbers(listOfNumbers);
            }
        }

        private static List<int> ConvertStringToIntegerList(String inputString, String regExPattern)
        {
            var numbers = Regex.Split(inputString, @$"{regExPattern}");
            return numbers.Select(a => Convert.ToInt32(a)).ToList();
        }
        
        private static int AddListOfPositiveNumbers(List<int> inputNumbers)
        {
            int sum = 0;
            List<int> negativeNumbers = new List<int>();
            foreach (var number in inputNumbers)
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