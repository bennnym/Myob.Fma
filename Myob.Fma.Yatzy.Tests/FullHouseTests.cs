using System.Collections.Generic;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Scoring;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class FullHouseTests
    {
        private readonly FullHouse _fullhouseCategory;

        public FullHouseTests()
        {
            _fullhouseCategory = new FullHouse();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_Return_The_Sum_Of_The_Dice_If_A_Perfect_Two_Of_A_Kind_And_Three_Of_A_Kind_Is_Present(
            List<IDice> roll, int expectedOutput)
        {
            // Act
            var rollTotal = _fullhouseCategory.GetScore(roll);

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
                        new Dice() {NumberRolled = 2},
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 3},
                    },
                    12
                },

                new object[]
                {
                    new List<IDice>
                    {
                        new Dice() {NumberRolled = 1},
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 1},
                    },
                    11
                }
            };

        [Theory]
        [MemberData(nameof(ZeroData))]
        public void Should_Return_Zero_If_A_Perfect_Two_Of_A_Kind_And_Three_Of_A_Kind_Isnt_Present(List<IDice> roll,
            int expectedOutput)
        {

            // Act
            var rollTotal = _fullhouseCategory.GetScore(roll);

            // Assert
            Assert.Equal(expectedOutput, rollTotal);
        }

        public static IEnumerable<object[]> ZeroData =>
            new List<object[]>
            {
                new object[]
                {
                    new List<IDice>
                    {
                        new Dice() {NumberRolled = 2},
                        new Dice() {NumberRolled = 2},
                        new Dice() {NumberRolled = 2},
                        new Dice() {NumberRolled = 2},
                        new Dice() {NumberRolled = 3},
                    },
                    0
                },

                new object[]
                {
                    new List<IDice>
                    {
                        new Dice() {NumberRolled = 4},
                        new Dice() {NumberRolled = 4},
                        new Dice() {NumberRolled = 4},
                        new Dice() {NumberRolled = 4},
                        new Dice() {NumberRolled = 4},
                    },
                    0
                }
            };
    }
}