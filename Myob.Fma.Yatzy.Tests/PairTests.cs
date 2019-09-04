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

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_Return_The_Sum_Of_The_Two_Highest_Matching_Numbers_When_Two_Dif_Pairs_Are_Present(
            List<IDice> roll, int expectedOutput)
        {
            // Act

            var rollTotal = _pairCategory.GetScore(roll);

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
                        new Dice() {NumberRolled = 2},
                        new Dice() {NumberRolled = 2},
                        new Dice() {NumberRolled = 4},
                        new Dice() {NumberRolled = 4},
                        new Dice() {NumberRolled = 1},
                    },
                    8
                },

                new object[]
                {
                    new List<IDice>
                    {
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 6},
                        new Dice() {NumberRolled = 6},
                        new Dice() {NumberRolled = 6},
                    },
                    12
                },
                new object[]
                {
                    new List<IDice>
                    {
                        new Dice() {NumberRolled = 1},
                        new Dice() {NumberRolled = 1},
                        new Dice() {NumberRolled = 2},
                        new Dice() {NumberRolled = 2},
                        new Dice() {NumberRolled = 6},
                    },
                    4
                }
            };

        [Theory]
        [MemberData(nameof(PairData))]
        public void Should_Return_The_Sum_Of_The_Highest_Pair_When_More_Than_Two_Of_That_Num_Are_Present(
            List<IDice> roll, int expected)
        {
            // Act

            var rollTotal = _pairCategory.GetScore(roll);

            // Assert

            Assert.Equal(expected, rollTotal);
        }

        public static IEnumerable<object[]> PairData =>
            new List<object[]>
            {
                new object[]
                {
                    new List<IDice>
                    {
                        new Dice() {NumberRolled = 2},
                        new Dice() {NumberRolled = 2},
                        new Dice() {NumberRolled = 2},
                        new Dice() {NumberRolled = 4},
                        new Dice() {NumberRolled = 1},
                    },
                    4
                },

                new object[]
                {
                    new List<IDice>
                    {
                        new Dice() {NumberRolled = 6},
                        new Dice() {NumberRolled = 6},
                        new Dice() {NumberRolled = 6},
                        new Dice() {NumberRolled = 6},
                        new Dice() {NumberRolled = 6},
                    },
                    12
                },
                new object[]
                {
                    new List<IDice>
                    {
                        new Dice() {NumberRolled = 4},
                        new Dice() {NumberRolled = 4},
                        new Dice() {NumberRolled = 4},
                        new Dice() {NumberRolled = 1},
                        new Dice() {NumberRolled = 1},
                    },
                    8
                }
            };

        [Fact]
        public void Should_Return_Zero_If_No_Pair_Of_Numbers_Are_Present()
        {
            // Arrange

            var roll = new List<IDice>
            {
                new Dice() {NumberRolled = 4},
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 2},
                new Dice() {NumberRolled = 5},
                new Dice() {NumberRolled = 1},            };

            //Act

            var rollTotal = _pairCategory.GetScore(roll);

            // Assert

            Assert.Equal(0, rollTotal);
        }
    }
}