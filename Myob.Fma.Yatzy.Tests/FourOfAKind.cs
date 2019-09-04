using System;
using System.Collections.Generic;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Scoring;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class FourOfAKindTests
    {
        private readonly FourOfAKind _fourOfAKind;

        public FourOfAKindTests()
        {
            _fourOfAKind = new FourOfAKind();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_Return_Sum_Of_Four_Matching_Dice_If_There_Are_Four_That_Match(List<IDice> roll,
            int expectedOutput)
        {
            // Act
            var rollTotal = _fourOfAKind.GetScore(roll);

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
                                      new Dice() {NumberRolled = 2},
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
                                      new Dice() {NumberRolled = 3},
                                      new Dice() {NumberRolled = 3},
                                      new Dice() {NumberRolled = 1},
                                  },
                                  12
                              }
                          };

        [Fact]
        public void Should_Return_Zero_When_No_Four_Of_A_Kind_Exists()
        {
            // Arrange
            var roll = new List<IDice>
            {
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 3},
                new Dice() {NumberRolled = 2},
                new Dice() {NumberRolled = 1},
            };

            // Act
            var rollTotal = _fourOfAKind.GetScore(roll);

            // Assert
            Assert.Equal(0, rollTotal);
        }
    }
}