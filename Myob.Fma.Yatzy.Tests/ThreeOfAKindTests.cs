using System;
using System.Collections.Generic;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Scoring;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class ThreeOfAKindTests
    {
        private readonly ThreeOfAKind _threeOfAKind;

        public ThreeOfAKindTests()
        {
            _threeOfAKind = new ThreeOfAKind();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_Return_Sum_Of_Three_Matching_Dice_If_There_Are_Three_That_Match(List<IDice> roll, int output)
        {
            // Act
            var rollTotal = _threeOfAKind.GetScore(roll);

            // Assert
            Assert.Equal(output, rollTotal);
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
                        new Dice() {NumberRolled = 2},
                        new Dice() {NumberRolled = 1},
                    },
                    6
                },

                new object[]
                {
                    new List<IDice>
                    {
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 3},
                        new Dice() {NumberRolled = 3},
                    },
                    9
                }
            };

        [Fact]
        public void Should_Return_Zero_When_No_Three_Of_A_Kind_Exists()
        {
            // Arrange
            var roll = new List<IDice>
            {
                new Dice() {NumberRolled = 1},
                new Dice() {NumberRolled = 2},
                new Dice() {NumberRolled = 5},
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 3},            };

            // Act
            var rollTotal = _threeOfAKind.GetScore(roll);

            // Assert
            Assert.Equal(0, rollTotal);
        }
    }
}