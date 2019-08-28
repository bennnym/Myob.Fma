using System;
using Xunit;

namespace Myob.Fma.StringCalculator.Tests
{
    public class StringCalculatorTests
    {
        private readonly StringCalculator _stringCalculator;

        public StringCalculatorTests()
        {
            _stringCalculator = new StringCalculator();
        }

        [Theory]
        [InlineData("5", 5)]
        [InlineData("10", 10)]
        [InlineData("13", 13)]
        public void Should_Return_The_String_As_A_Integer_When_A_Single_Number_Is_Input(string num, int expectedOutput)
        {
            var result = _stringCalculator.Add(num);

            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void Should_Return_Zero_When_An_Empty_String_Is_Input()
        {
            var result = _stringCalculator.Add(string.Empty);

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("3,5", 8)]
        [InlineData("1,2,3", 6)]
        [InlineData("3,5,3,9", 20)]
        public void Should_Return_The_Sum_Of_The_Strings_When_Multiple_Numbers_Are_Entered(string input,
            int expectedOutput)
        {
            var result = _stringCalculator.Add(input);

            Assert.Equal(expected: expectedOutput, result);
        }

        [Theory]
        [InlineData("1,2\n3", 6)]
        [InlineData("3\n5\n3,9", 20)]
        public void Should_Return_The_Sum_Of_The_Strings_When_Line_Breaks_And_Commas_Are_Used_As_Separators(
            string input,
            int expectedOutput)
        {
            var result = _stringCalculator.Add(input);

            Assert.Equal(expected: expectedOutput, result);
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//*\n4*6", 10)]
        public void Should_Return_The_Sum_Of_The_Strings_With_A_Specific_Delimiter_Provided(string input,
            int expectedOutput)
        {
            var result = _stringCalculator.Add(input);
            
            Assert.Equal(expected: expectedOutput, result);
        }

        [Fact]
        public void Should_Throw_An_Exception_When_A_Negative_Number_Is_In_The_Input_String()
        {
            var exception = Assert.Throws<Exception>(() => _stringCalculator.Add("-1,2,-3"));
            
            Assert.Equal("-1, -3", exception.Message);
        }

        [Theory]
        [InlineData("1000,1001,2", 2)]
        [InlineData("10000,3000,100, 7", 107)]
        public void Should_Ignore_Numbers_That_Are_Greater_Than_1000_And_Sum_Other_Numbers(string inputString, int expectedOutput)
        {
            var result = _stringCalculator.Add(inputString);
            
            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void Should_Register_Optional_Delimiters_Of_Any_Length_Surrounded_By_Square_Brackets()
        {
            var result = _stringCalculator.Add("//[***]\n1***2***3");
            
            Assert.Equal(6, result);
        }

        [Theory]
        [InlineData("//[*][%]\n1*2%3", 6)]
        public void Should_Be_Able_To_Enter_Multiple_Delimiters_And_Return_Sum(string input, int expectedOutput)
        {
            // act

            var result = _stringCalculator.Add(input);
            
            // assert
            Assert.Equal(expectedOutput,result);

        }

        [Fact]
        public void Should_Be_Able_To_Input_A_Custom_Delimeter_With_A_Integer_Inbetween_And_Sum_Is_Still_Valid()
        {
            //act
            var result = _stringCalculator.Add("//[*1*][%]\n1*1*2%3");
            //assert
            Assert.Equal(6,result);
        }
        
    }
}