using System.Collections.Generic;
using System.Data;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Enums;
using Myob.Fma.Yatzy.Scoring;
using Xunit;
using Xunit.Sdk;

namespace Myob.Fma.Yatzy
{
    public class DiceNumberTests
    {
        private readonly Dice _sideOne;
        private readonly Dice _sideTwo;
        private readonly Dice _sideThree;
        private readonly Dice _sideFour;
        private readonly Dice _sideFive;
        private readonly Dice _sideSix;
        private readonly DiceNumber _diceNumberCategory;

        public DiceNumberTests()
        {
            _sideOne = new Dice() {NumberRolled = 1};
            _sideTwo = new Dice() {NumberRolled = 2};
            _sideThree = new Dice() {NumberRolled = 3};
            _sideFour = new Dice() {NumberRolled = 4};
            _sideFive = new Dice() {NumberRolled = 5};
            _sideSix = new Dice() {NumberRolled = 6};

            _diceNumberCategory = new DiceNumber();
        }

        [Fact]
        public void Should_Return_Sum_Of_Ones_When_They_Are_Present_In_Roll()
        {
            // Arrange
            var roll = new List<IDice>
            {
                _sideOne,
                _sideOne,
                _sideTwo,
                _sideFour,
                _sideFour
            };


            // Act
            var rollTotal = _diceNumberCategory.GetScore(roll, NumberCategory.Ones);

            // Assert
            Assert.Equal(2, rollTotal);
        }

        [Fact]
        public void Should_Return_Zero_If_NumberCategory_Has_No_IDice_Matching_That_Number()
        {
            // Arrange
            var roll = new List<IDice>
            {
                _sideFive,
                _sideThree,
                _sideTwo,
                _sideFour,
                _sideSix
            };

            // Act
            var rollTotal = _diceNumberCategory.GetScore(roll, NumberCategory.Ones);

            // Assert
            Assert.Equal(0, rollTotal);
        }

        [Fact]
        public void Should_Throw_NotNullAllowedException_When_NumberCategory_Is_Left_As_Null()
        {
            // Arrange
            var roll = new List<IDice>
            {
                _sideFive,
                _sideThree,
                _sideTwo,
                _sideFour,
                _sideSix
            };

            // Assert
            var exception = Assert.Throws<NoNullAllowedException>(() => _diceNumberCategory.GetScore(roll));

            Assert.Equal("A number category must be entered as an argument.", exception.Message);
        }
        
    }
}