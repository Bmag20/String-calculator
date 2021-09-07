using StringCalculator;
using Xunit;

namespace StringCalculatorTests
{
    public class UnitTest1
    {
        [Fact]
        public void Empty_string_returns_0()
        {
            Assert.Equal(0, Calculator.Add(""));
        }

        [Fact]
        public void A_single_number_returns_that_number()
        {
            Assert.Equal(3, Calculator.Add("3"));
        }
    }
}