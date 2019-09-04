using System.Collections.Generic;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Scoring;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class TwoPairsTests
    {
        private readonly TwoPairs _twoPairsCategory;

        public TwoPairsTests()
        {
            _twoPairsCategory = new TwoPairs();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_Return_The_Sum_Of_The_Two_Largest_Pairs(List<IDice> roll, int expected)
        {
            // Act
            var rollTotal = _twoPairsCategory.GetScore(roll);

            // Assert
            Assert.Equal(expected, rollTotal);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    new List<IDice>
                    {
                        new Dice() {NumberRolled = 2},
                        new Dice() {NumberRolled = 2},
                        new Dice() {NumberRolled = 6},
                        new Dice() {NumberRolled = 6},
                        new Dice() {NumberRolled = 1},
                    },
                    16
                },

                new object[]
                {
                    new List<IDice>
                    {
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 1},
                        new Dice() {NumberRolled = 1},
                    },
                    8
                }
            };

        [Fact]
        public void Should_Return_Zero_When_There_Arent_Two_Pairs_Present_In_The_Roll()
        {
            // Arrange
            var roll = new List<IDice>
            {
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 3},            };

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
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 1},
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 4},
                new Dice() {NumberRolled = 2},            };

            // Act
            var rollTotal = _twoPairsCategory.GetScore(roll);

            // Assert
            Assert.Equal(0, rollTotal);
        }
    }
}