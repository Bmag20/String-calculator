using System;
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
            Assert.Equal(3, Calculator.Add("//*\n1*2"));

        }

        [Fact]
        public void A_negative_number_will_throw_Negatives_not_allowed_exception_along_with_the_passed_negative_number()
        {
            var ex = Assert.Throws<FormatException>(() => Calculator.Add("-1,2,-3"));
            Assert.Equal("Negatives not allowed: -1, -3", ex.Message);
        }
        
        [Fact]
        public void Numbers_greater_or_equal_to_1000_should_be_ignored()
        {
            Assert.Equal(2, Calculator.Add("1000,1001,2"));
        }
        
        [Fact]
        public void Delimiters_can_be_of_any_length_with_the_following_format()
        {
            Assert.Equal(6, Calculator.Add("//[***]\n1***2***3"));
        }
        
        [Fact]
        public void Allow_multiple_delimiters()
        {
            Assert.Equal(6, Calculator.Add("//[*][%]\n1*2%3"));
        }
        
        [Fact]
        public void Handle_multiple_delimiters_with_a_length_longer_than_one_character()
        {
            Assert.Equal(10, Calculator.Add("//[***][#][%]\n1***2#3%4"));
        }
        
        [Fact]
        public void Handle_delimiters_that_have_numbers_as_part_of_them_number_not_being_on_the_edge()
        {
            Assert.Equal(10, Calculator.Add("//[*1*][%]\n1*1*2%3"));
        }
    }
}