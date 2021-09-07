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
            if (input.Contains(","))
            {
                var numbers = input.Split(",");
                return numbers.Sum(Convert.ToInt32);
            }
            return Convert.ToInt32(input);
        }
    }
}