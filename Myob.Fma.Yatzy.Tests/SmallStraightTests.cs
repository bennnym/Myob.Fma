using System.Collections.Generic;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Scoring;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class SmallStraightTests
    {
        [Fact]
        public void Should_Return_Sum_Of_Roll_When_A_Small_Straight_Is_Present_12345()
        {
            // Arrange
            var smallStraightCategory = new SmallStraight();
            
            var roll = new List<IDice>
            {
                new Dice() {NumberRolled = 1},
                new Dice() {NumberRolled = 2},
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 4},
                new Dice() {NumberRolled = 5}
            };

            // Act
            var rollTotal = smallStraightCategory.GetScore(roll);

            // Assert
            Assert.Equal(15, rollTotal);
        }

        [Fact]
        public void Should_Return_Zero_When_No_Small_Straight_Is_Present()
        {
            // Arrange
            var smallStraightCategory = new SmallStraight();
            
            var roll = new List<IDice>
            {
                new Dice() {NumberRolled = 2},
                new Dice() {NumberRolled = 2},
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 4},
                new Dice() {NumberRolled = 6}
            };

            // Act
            var rollTotal = smallStraightCategory.GetScore(roll);

            // Assert
            Assert.Equal(0, rollTotal);
            
        }
    }
}