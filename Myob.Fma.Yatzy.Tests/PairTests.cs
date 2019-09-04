using System.Collections.Generic;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Scoring;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class PairTests
    {
        private readonly Dice _sideOne;
        private readonly Dice _sideTwo;
        private readonly Dice _sideThree;
        private readonly Dice _sideFour;
        private readonly Dice _sideFive;
        private readonly Dice _sideSix;
        private readonly Pair _pairCategory;

        public PairTests()
        {
            _sideOne = new Dice() {NumberRolled = 1};
            _sideTwo = new Dice() {NumberRolled = 2};
            _sideThree = new Dice() {NumberRolled = 3};
            _sideFour = new Dice() {NumberRolled = 4};
            _sideFive = new Dice() {NumberRolled = 5};
            _sideSix = new Dice() {NumberRolled = 6};
            _pairCategory = new Pair();
        }

        [Fact]
        public void Should_Return_The_Sum_Of_The_Two_Highest_Matching_Numbers_When_Two_Dif_Pairs_Are_Present()
        {
            // Arrange
            
            var roll = new List<IDice>
            {
                _sideThree, _sideThree, _sideThree, _sideFour, _sideFour
            };

            // Act
            
            var rollTotal = _pairCategory.GetScore(roll);

            // Assert
            
            Assert.Equal(8, rollTotal);
        }
        
        [Fact]
        public void Should_Return_The_Sum_Of_The__Highest_Paur_When_More_Than_Two_Of_That_Num_Are_Present()
        {
            // Arrange
            
            var roll = new List<IDice>
            {
                _sideThree, _sideThree, _sideThree, _sideThree, _sideFour
            };

            // Act
            
            var rollTotal = _pairCategory.GetScore(roll);

            // Assert
            
            Assert.Equal(6, rollTotal);
        }

        [Fact]
        public void Should_Return_Zero_If_No_Pair_Of_Numbers_Are_Present()
        {
            // Arrange

            var roll = new List<IDice>
            {
                _sideThree, _sideTwo, _sideOne, _sideFive, _sideSix
            };

            //Act

            var rollTotal = _pairCategory.GetScore(roll);

            // Assert

            Assert.Equal(0, rollTotal);
        }
    }
}