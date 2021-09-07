using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public static class Calculator
    {
        public static int Add(String input)
        {
            if (input == "")
                return 0;
            if (Regex.Match(input, @"//.\n\d(.\d)+").Success)
            {
                var inputAfterNewLine = input.Split("\n")[1];
                var listOfNumbers = ConvertStringToIntegerList(inputAfterNewLine, new char[]{input[2]});
                return AddListOfPositiveNumbers(listOfNumbers);
            }
            if (Regex.IsMatch(input, @"\d(\\n|,\d)+"))
            {
                var listOfNumbers = ConvertStringToIntegerList(input, new char[]{',', '\n'});
                return AddListOfPositiveNumbers(listOfNumbers);
            }
            return Convert.ToInt32(input);
        }

        private static List<int> ConvertStringToIntegerList(String inputString, char[] delimiters)
        {
            var numbers = inputString.Split(delimiters);
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