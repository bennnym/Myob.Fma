using System;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class ChanceTests
    {
        [Theory]
        [InlineData(1, 1, 3, 3, 6, 14)]
        [InlineData(4, 5, 5, 6, 1, 21)]
        public void Should_Return_Sum_Of_All_Dice_Rolls(int dice1, int dice2, int dice3, int dice4, int dice5,
             int expectedOutput)
        {
            //Arrange
            var rollTotal = EvaluateScore.Chance
                (dice1, dice2, dice3, dice4, dice5);
            //Assert
            Assert.Equal(expectedOutput,rollTotal);
        }
    }
}