using System;
using Xunit;

namespace Myob.Fma.Calculator.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;
        
        public CalculatorTests()
        {
            _calculator = new Calculator();
        }
        
        [Theory]
        [InlineData(new int[] { 5,6 }, 11)]
        [InlineData(new int[] { 5,6,7 }, 18)]
        [InlineData(new int[] { 5,6,7, 8 }, 26)]
        public void Should_Add_Return_Sum_When_Given_Input_Data(int[] inputs, int expected)
        {

            //Act
            var result = _calculator.Add(inputs);
            
            //Assert
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(new int[] {3,5,10}, 18)]
        public void Should_Add_Return_Sum_When_Three_Input_Integers(int[] input, int expectedOutput)
        {

            //Act
            var result = _calculator.Add(input);
            
            //Assert
            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void Should_Multiply_Return_Product_Of_Numbers_When_Two_Input_Integers()
        {
            var x = 5;
            var y = 10;

            var result = _calculator.Multiply(x, y);
            
            Assert.Equal(50, result);
        }

        [Fact]
        public void Should_LargerThan_Return_True_If_First_Paramater_Is_Greater_Than_Second_Paramater()
        {
            var x = 10;
            var y = 5;

            var result = _calculator.LargerThan(x, y);
            
            Assert.True(result);
        }

    }
}