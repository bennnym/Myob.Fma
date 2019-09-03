using Xunit;

namespace Myob.Fma.Yatzy
{
    public class DiceNumbersTests
    {
        [Theory]
        [InlineData(NumberCategory.Fours,1,1,2,4,4,8)]
        [InlineData(NumberCategory.Twos,2,3,2,5,1,4)]
        [InlineData(NumberCategory.Ones,3,3,3,4,5,0)]
        public void Should_Return_Sum_Of_Specified_Number_Amongst_Input_Rolls(NumberCategory selectedNumber, int dice1, int dice2, int dice3, int dice4, int dice5, int expectedOutput)
        {
            // Arrange
            var rollTotal = EvaluateScore.DiceNumber(selectedNumber, dice1, dice2, dice3, roll4, dice5);
            // Assert
            Assert.Equal(expectedOutput,rollTotal);
        }

        [Fact]
        public void Should_Return_Zero_If_NumberCategory_Has_No_Dice_Matching_That_Numeber()
        {
            // Act
            var rollTotal = EvaluateScore.DiceNumber(NumberCategory.Ones, 2, 3, 4, 5, 6);
            // Assert
            Assert.Equal(0,rollTotal);
        }

    }
}