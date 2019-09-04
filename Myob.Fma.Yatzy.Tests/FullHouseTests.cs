using System.Collections.Generic;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Scoring;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class FullHouseTests
    {
        [Fact]
        public void Should_Return_The_Sum_Of_The_Dice_If_A_Perfect_Two_Of_A_Kind_And_Three_Of_A_Kind_Is_Present()
        {
            // Arrange
            var fullHouseCategory = new FullHouse();
            
            var roll = new List<IDice>
            {
                new Dice() {NumberRolled = 4},
                new Dice() {NumberRolled = 4},
                new Dice() {NumberRolled = 4},
                new Dice() {NumberRolled = 6},
                new Dice() {NumberRolled = 6}
            };

            // Act
            var rollTotal = fullHouseCategory.GetScore(roll);

            // Assert
            Assert.Equal(24, rollTotal);
        }
        
        [Fact]
        public void Should_Return_Zero_If_A_Perfect_Two_Of_A_Kind_And_Three_Of_A_Kind_Isnt_Present()
        {
            // Arrange
            var fullHouseCategory = new FullHouse();

            var roll = new List<IDice>
            {
                new Dice() {NumberRolled = 4},
                new Dice() {NumberRolled = 1},
                new Dice() {NumberRolled = 4},
                new Dice() {NumberRolled = 6},
                new Dice() {NumberRolled = 6}
            };

            // Act
            var rollTotal = fullHouseCategory.GetScore(roll);

            // Assert
            Assert.Equal(0, rollTotal);
        }
    }
}