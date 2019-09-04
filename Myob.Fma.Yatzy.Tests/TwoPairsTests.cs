using System.Collections.Generic;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Scoring;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class TwoPairsTests
    {
        private readonly Dice _sideOne;
        private readonly Dice _sideTwo;
        private readonly Dice _sideThree;
        private readonly Dice _sideFour;
        private readonly Dice _sideFive;
        private readonly Dice _sideSix;
        private readonly TwoPairs _twoPairsCategory;

        public TwoPairsTests()
        {
            _sideOne = new Dice() {NumberRolled = 1};
            _sideTwo = new Dice() {NumberRolled = 2};
            _sideThree = new Dice() {NumberRolled = 3};
            _sideFour = new Dice() {NumberRolled = 4};
            _sideFive = new Dice() {NumberRolled = 5};
            _sideSix = new Dice() {NumberRolled = 6};
            _twoPairsCategory = new TwoPairs();
        }
        [Fact]
        public void Should_Return_The_Sum_Of_The_Two_Largest_Pairs()
        {
            // Arrange
            var roll = new List<IDice>
            {
                _sideThree, _sideThree, _sideThree, _sideFour, _sideFour
            };
            
            // Act
            var rollTotal = _twoPairsCategory.GetScore(roll);

            // Assert
            Assert.Equal(14, rollTotal);
        }

        [Fact]
        public void Should_Return_Zero_When_There_Arent_Two_Pairs_Present_In_The_Roll()
        {
            // Arrange
            var roll = new List<IDice>
            {
                _sideThree, _sideTwo, _sideSix, _sideFive, _sideFour
            };
            
            // Act
            var rollTotal = _twoPairsCategory.GetScore(roll);
            // Assert
            Assert.Equal(0, rollTotal);
        }

        [Fact]
        public void Should_Return_Zero_When_There_Is_Only_One_Pair_Present()
        {
            // Arrange
            var roll = new List<IDice>
            {
                _sideOne, _sideOne, _sideOne, _sideOne, _sideFour
            };
            
            // Act
            var rollTotal = _twoPairsCategory.GetScore(roll);
            
            // Assert
            Assert.Equal(0, rollTotal);
        }
    }
}