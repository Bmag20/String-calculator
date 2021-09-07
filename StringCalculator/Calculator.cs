using System;

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
                return Convert.ToInt32(numbers[0]) + Convert.ToInt32(numbers[1]);
            }
            return Convert.ToInt32(input);
        }
    }
}