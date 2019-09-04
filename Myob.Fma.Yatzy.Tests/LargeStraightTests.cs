using System.Collections.Generic;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Scoring;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class LargeStraightTests
    {
        [Fact]
        public void Should_Return_Sum_Of_Roll_When_A_Large_Straight_Is_Present_23456()
        {
            // Arrange
            var largeStraightCategory = new LargeStraight();
            
            var roll = new List<IDice>
            {
                new Dice() {NumberRolled = 6},
                new Dice() {NumberRolled = 2},
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 4},
                new Dice() {NumberRolled = 5}
            };

            // Act
            var rollTotal = largeStraightCategory.GetScore(roll);

            // Assert
            Assert.Equal(20, rollTotal);
        }
        
        [Fact]
        public void Should_Return_Zero_When_No_Large_Straight_Is_Present()
        {
            // Arrange
            var largeStraightCategory = new LargeStraight();
            
            var roll = new List<IDice>
            {
                new Dice() {NumberRolled = 2},
                new Dice() {NumberRolled = 2},
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 4},
                new Dice() {NumberRolled = 6}
            };

            // Act
            var rollTotal = largeStraightCategory.GetScore(roll);

            // Assert
            Assert.Equal(0, rollTotal);
            
        }
    }
}