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
            Assert.Equal(1, Calculator.Add("1"));
            Assert.Equal(3, Calculator.Add("3"));
        }
        
        [Fact]
        public void Two_numbers_returns_the_sum_of_the_numbers()
        {
            Assert.Equal(3, Calculator.Add("1,2"));
            Assert.Equal(8, Calculator.Add("3,5"));
        }
        
        [Fact]
        public void Any_amount_of_numbers_returns_the_sum_of_those_numbers()
        {
            Assert.Equal(6, Calculator.Add("1,2,3"));
            Assert.Equal(20, Calculator.Add("3,5,3,9"));
        }

        [Fact]
        public void New_line_breaks_and_commas_should_be_interchangeable_between_numbers()
        {
            Assert.Equal(6, Calculator.Add("1,2\n3"));
            Assert.Equal(20, Calculator.Add("3\n5\n3,9"));
        }

        [Fact]
        public void Support_single_character_delimiter_given_in_appropriate_format()
        {
            Assert.Equal(3, Calculator.Add("//;\n1;2"));
        }
    }
}