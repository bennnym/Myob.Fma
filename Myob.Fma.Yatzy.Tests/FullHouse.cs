namespace Myob.Fma.Yatzy
{
    public class FullHouse
    {
        [Fact]
        public void Should_Return_The_Sum_Of_The_Dice_If_A_Perfect_Two_Of_A_Kind_And_Three_Of_A_Kind_Is_Present()
        {
            // Arrange
            var roll = new List<IDice>
            {
                new IDice {ActiveSide = 1},
                new IDice {ActiveSide = 1},
                new IDice {ActiveSide = 2},
                new IDice {ActiveSide = 2},
                new IDice {ActiveSide = 2},
            };

            // Act
            var rollTotal = EvaluateScore.FullHouse(roll);

            // Assert
            Assert.Equal(8, rollTotal);
        }
        
        [Fact]
        public void Should_Return_Zero_If_A_Perfect_Two_Of_A_Kind_And_Three_Of_A_Kind_Isnt_Present()
        {
            // Arrange
            var roll = new List<IDice>
            {
                new IDice {ActiveSide = 1},
                new IDice {ActiveSide = 1},
                new IDice {ActiveSide = 1},
                new IDice {ActiveSide = 1},
                new IDice {ActiveSide = 2},
            };

            // Act
            var rollTotal = EvaluateScore.FullHouse(roll);

            // Assert
            Assert.Equal(decimal.Zero, rollTotal);
        }
    }
}