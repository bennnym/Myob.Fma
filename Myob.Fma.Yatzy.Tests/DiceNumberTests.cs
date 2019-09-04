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
        private readonly DiceNumber _diceNumberCategory;

        public DiceNumberTests()
        {
            _diceNumberCategory = new DiceNumber();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_Return_Sum_Of_Num_Category_Occurunces_When_They_Are_Present_In_Roll(List<IDice> roll,
            NumberCategory numberCategory, int expectedOutput)
        {
            // Act
            var rollTotal = _diceNumberCategory.GetScore(roll, numberCategory);

            // Assert
            Assert.Equal(expectedOutput, rollTotal);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    new List<IDice>
                    {
                        new Dice() {NumberRolled = 1},
                        new Dice() {NumberRolled = 1},
                        new Dice() {NumberRolled = 5},
                        new Dice() {NumberRolled = 4},
                        new Dice() {NumberRolled = 4},
                    },
                    NumberCategory.Ones,
                    2
                },

                new object[]
                {
                    new List<IDice>
                    {
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 6},
                        new Dice() {NumberRolled = 4},
                        new Dice() {NumberRolled = 1},
                    },
                    NumberCategory.Sixes,
                    6
                },
                new object[]
                {
                    new List<IDice>
                    {
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 6},
                        new Dice() {NumberRolled = 4},
                        new Dice() {NumberRolled = 4},
                    },
                    NumberCategory.Fours,
                    8
                }
            };

        [Fact]
        public void Should_Return_Zero_If_NumberCategory_Has_No_IDice_Matching_That_Number()
        {
            // Arrange
            var roll = new List<IDice>
            {
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 6},
                new Dice() {NumberRolled = 4},
                new Dice() {NumberRolled = 4},
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
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 6},
                new Dice() {NumberRolled = 4},
                new Dice() {NumberRolled = 4},
            };

            // Assert
            var exception = Assert.Throws<NoNullAllowedException>(() => _diceNumberCategory.GetScore(roll));

            Assert.Equal("A number category must be entered as an argument.", exception.Message);
        }
    }
}