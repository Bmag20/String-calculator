using System;

namespace StringCalculator
{
    public static class Calculator
    {
        public static int Add(String input)
        {
            if (input == "")
                return 0;
            else
                return Convert.ToInt32(input);
        }
    }
}