using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public static class Calculator
    {
        public static int Add(String input)
        {
            Console.WriteLine("hi");
            if (input == "")
                return 0;
            if (Regex.Match(input, @"//.\n\d(.\d)+").Success)
            {
                Console.WriteLine(input[2]);
                var numbers = input.Split("\n")[1].Split(input[2]);
                Console.WriteLine(numbers[0]);
                return numbers.Sum(Convert.ToInt32);
            }
            if (Regex.IsMatch(input, @"\d(\\n|,\d)+"))
            {
                var numbers = input.Split(new char [] {',', '\n'});
                return numbers.Sum(Convert.ToInt32);
            }
            return Convert.ToInt32(input);
        }
    }
}