using System;
using System.Collections.Generic;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Scoring;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class FourOfAKindTests
    {
        private readonly Dice _sideOne;
        private readonly Dice _sideTwo;
        private readonly Dice _sideThree;
        private readonly Dice _sideFour;
        private readonly Dice _sideFive;
        private readonly Dice _sideSix;
        private readonly FourOfAKind _fourOfAKind;

        public FourOfAKindTests()
        {
            _sideOne = new Dice() {NumberRolled = 1};
            _sideTwo = new Dice() {NumberRolled = 2};
            _sideThree = new Dice() {NumberRolled = 3};
            _sideFour = new Dice() {NumberRolled = 4};
            _sideFive = new Dice() {NumberRolled = 5};
            _sideSix = new Dice() {NumberRolled = 6};
            _fourOfAKind = new FourOfAKind();
        }
        [Fact]
        public void Should_Return_Sum_Of_Four_Matching_Dice_If_There_Are_Four_That_Match()
        {
            // Arrange
            var roll = new List<IDice>
            {
                _sideThree, _sideThree, _sideThree, _sideThree, _sideFour
            };
            
            // Act
            var rollTotal = _fourOfAKind.GetScore(roll);
            
            // Assert
            Assert.Equal(12,rollTotal);
        }

        [Fact]
        public void Should_Return_Zero_When_No_Four_Of_A_Kind_Exists()
        {
            // Arrange
            var roll = new List<IDice>
            {
                _sideTwo, _sideOne, _sideThree, _sideFour, _sideFive
            };
            
            // Act
            var rollTotal = _fourOfAKind.GetScore(roll);
            
            // Assert
            Assert.Equal(0,rollTotal);
        }
    }
}