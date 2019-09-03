using System.Collections.Generic;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class TwoPairsTests
    {
        [Theory]
        [InlineData(new List <IDice> {new IDice() {ActiveSide = 1},new IDice() {ActiveSide = 1},new IDice() {ActiveSide = 2},new IDice() {ActiveSide = 3},new IDice() {ActiveSide = 3}}, 8)]
        [InlineData(new List <IDice> {new IDice() {ActiveSide = 1},new IDice() {ActiveSide = 1},new IDice() {ActiveSide = 2},new IDice() {ActiveSide = 2},new IDice() {ActiveSide = 2}}, 6)]

        public void Should_Return_The_Sum_Of_The_Two_Largest_Pairs(List<IDice> roll, int expectedOutput)
        {
            // Act
            var rollTotal = EvaluateScore.TwoPairs(roll);

            // Assert
            Assert.Equal(expectedOutput, rollTotal);
        }

        [Fact]
        public void Should_Return_Zero_When_There_Arent_Two_Pairs_Present_In_The_Roll()
        {
            // Arrange
            var roll = new List<IDice>
            {
                new IDice {ActiveSide = 1},
                new IDice {ActiveSide = 2},
                new IDice {ActiveSide = 3},
                new IDice {ActiveSide = 3},
                new IDice {ActiveSide = 4},
            };
            
            // Act
            var rollTotal = EvaluateScore.TwoPairs(roll);
            // Assert
            Assert.Equal(decimal.Zero, rollTotal);
        }
    }
}