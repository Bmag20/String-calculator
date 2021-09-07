using StringCalculator;
using Xunit;

namespace StringCalculatorTests
{
    public class UnitTest1
    {
        [Fact]
        public void Adding_empty_string_gives_0()
        {
            Assert.Equal(0, Calculator.Add(""));
        }
    }
}