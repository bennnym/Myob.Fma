using System.Collections.Generic;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class PairTests
    {
        [Theory]
        [InlineData(new List<IDice>{new IDice(){ActiveSide = 3},new IDice(){ActiveSide = 3},new IDice(){ActiveSide = 3},new IDice(){ActiveSide = 4},new IDice(){ActiveSide = 4}},8)]
        [InlineData(new List<IDice>{new IDice(){ActiveSide = 1},new IDice(){ActiveSide = 1},new IDice(){ActiveSide = 6},new IDice(){ActiveSide = 2},new IDice(){ActiveSide = 6}},12)]
        [InlineData(new List<IDice>{new IDice(){ActiveSide = 3},new IDice(){ActiveSide = 3},new IDice(){ActiveSide = 3},new IDice(){ActiveSide = 3},new IDice(){ActiveSide = 1}},6)]
        public void Should_Return_The_Sum_Of_The_Two_Highest_Matching_Numbers(List<IDice> roll, int expectedOutput)
        {
            // Arrange
            var rollTotal = EvaluateScore.Pairs(roll);
            
            // Assert
            Assert.Equal(expectedOutput, rollTotal);
        }

        [Fact]
        public void Should_Return_Zero_If_No_Pair_Of_Numbers_Are_Present()
        {
            // Arrange
            var rollTotal = EvaluateScore.Pairs(1, 2, 3, 4, 5);
            // Assert
            Assert.Equal(decimal.Zero,rollTotal);
        }
            
    }
}