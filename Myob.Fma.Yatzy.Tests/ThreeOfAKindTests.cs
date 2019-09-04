using System;
using System.Collections.Generic;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Scoring;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class ThreeOfAKindTests
    {
        private readonly Dice _sideOne;
        private readonly Dice _sideTwo;
        private readonly Dice _sideThree;
        private readonly Dice _sideFour;
        private readonly Dice _sideFive;
        private readonly Dice _sideSix;
        private readonly ThreeOfAKind _threeOfAKind;

        public ThreeOfAKindTests()
        {
            _sideOne = new Dice() {NumberRolled = 1};
            _sideTwo = new Dice() {NumberRolled = 2};
            _sideThree = new Dice() {NumberRolled = 3};
            _sideFour = new Dice() {NumberRolled = 4};
            _sideFive = new Dice() {NumberRolled = 5};
            _sideSix = new Dice() {NumberRolled = 6};
            _threeOfAKind = new ThreeOfAKind();
        }
        [Fact]
        public void Should_Return_Sum_Of_Three_Matching_Dice_If_There_Are_Three_That_Match()
        {
            // Arrange
            var roll = new List<IDice>
            {
                _sideThree, _sideThree, _sideThree, _sideSix, _sideFour
            };
            
            // Act
            var rollTotal = _threeOfAKind.GetScore(roll);
            
            // Assert
            Assert.Equal(9,rollTotal);
        }

        [Fact]
        public void Should_Return_Zero_When_No_Three_Of_A_Kind_Exists()
        {
            // Arrange
            var roll = new List<IDice>
            {
                _sideTwo, _sideOne, _sideThree, _sideFour, _sideFive
            };
            
            // Act
            var rollTotal = _threeOfAKind.GetScore(roll);
            
            // Assert
            Assert.Equal(0,rollTotal);
        }

    }
}