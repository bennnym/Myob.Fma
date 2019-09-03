using System.Collections.Generic;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class PairTests
    {
        [Theory]
        [InlineData(new List<Dice>{new Dice(){RolledSide = 3},new Dice(){RolledSide = 3},new Dice(){RolledSide = 3},new Dice(){RolledSide = 4},new Dice(){RolledSide = 4}},8)]
        [InlineData(new List<Dice>{new Dice(){RolledSide = 1},new Dice(){RolledSide = 1},new Dice(){RolledSide = 6},new Dice(){RolledSide = 2},new Dice(){RolledSide = 6}},12)]
        [InlineData(new List<Dice>{new Dice(){RolledSide = 3},new Dice(){RolledSide = 3},new Dice(){RolledSide = 3},new Dice(){RolledSide = 3},new Dice(){RolledSide = 1}},6)]
        public void Should_Return_The_Sum_Of_The_Two_Highest_Matching_Numbers(List<Dice> roll, int expectedOutput)
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
            Assert.Equal(0,rollTotal);
        }
            
    }
}