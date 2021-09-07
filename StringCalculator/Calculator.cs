using System;
using System.Linq;

namespace StringCalculator
{
    public static class Calculator
    {
        public static int Add(String input)
        {
            if (input == "")
                return 0;
            if (input.Contains(",") || input.Contains("\n"))
            {
                var numbers = input.Split(new char [] {',', '\n'});
                return numbers.Sum(Convert.ToInt32);
            }
            return Convert.ToInt32(input);
        }
    }
}