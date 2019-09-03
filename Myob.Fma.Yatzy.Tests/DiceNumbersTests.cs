using System.Collections.Generic;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class IDiceNumbersTests
    {
        [Theory]
        [InlineData(NumberCategory.Fours,new List<IDice>{new IDice(){ActiveSide = 1},new IDice(){ActiveSide = 1},new IDice(){ActiveSide = 2},new IDice(){ActiveSide = 4},new IDice(){ActiveSide = 4}},8)]
        [InlineData(NumberCategory.Twos,new List<IDice>{new IDice(){ActiveSide = 2},new IDice(){ActiveSide = 3},new IDice(){ActiveSide = 2},new IDice(){ActiveSide = 5},new IDice(){ActiveSide = 1}},4)]
        [InlineData(NumberCategory.Ones,new List<IDice>{new IDice(){ActiveSide = 3},new IDice(){ActiveSide = 3},new IDice(){ActiveSide = 3},new IDice(){ActiveSide = 4},new IDice(){ActiveSide = 5}},0)]
        public void Should_Return_Sum_Of_Specified_Number_Amongst_Input_Rolls(NumberCategory selectedNumber, List<IDice> roll, int expectedOutput)
        {
            // Arrange
            var rollTotal = EvaluateScore.IDiceNumber(selectedNumber, roll);
            // Assert
            Assert.Equal(expectedOutput,rollTotal);
        }

        [Fact]
        public void Should_Return_Zero_If_NumberCategory_Has_No_IDice_Matching_That_Numeber()
        {
            // Act
            var rollTotal = EvaluateScore.IDiceNumber(NumberCategory.Ones, 2, 3, 4, 5, 6);
            // Assert
            Assert.Equal(decimal.Zero,rollTotal);
        }

    }
}