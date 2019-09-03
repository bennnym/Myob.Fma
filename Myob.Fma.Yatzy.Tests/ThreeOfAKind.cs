using System;
using System.Collections.Generic;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class ThreeOfAKind
    {
        [Theory]
        [InlineData(new List <IDice> {new IDice() {ActiveSide = 3},new IDice() {ActiveSide = 3},new IDice() {ActiveSide = 3},new IDice() {ActiveSide = 4},new IDice() {ActiveSide = 5}}, 9)]
        [InlineData(new List <IDice> {new IDice() {ActiveSide = 3},new IDice() {ActiveSide = 3},new IDice() {ActiveSide = 3},new IDice() {ActiveSide = 3},new IDice() {ActiveSide = 5}}, 9)]
        public void Should_Return_Sum_Of_Three_Matching_Dice_If_There_Are_Three_That_Match(List<IDice> roll, int expectedOutput)
        {
            // Act
            var rollTotal = EvaluateScore.ThreeOfAKind(roll);
            
            // Assert
            Assert.Equal(expectedOutput,rollTotal);
        }

        [Fact]
        public void Should_Return_Zero_When_No_Three_Of_A_Kind_Exists()
        {
            // Arrange
            var roll = new List<IDice>
            {
                new IDice{ ActiveSide = 1},
                new IDice{ ActiveSide = 2},
                new IDice{ ActiveSide = 3},
                new IDice{ ActiveSide = 4},
                new IDice{ ActiveSide = 5},
            };
            
            // Act
            var rollTotal = EvaluateScore.ThreeOfAKind(roll);
            
            // Assert
            Assert.Equal(decimal.Zero, rollTotal);
        }

    }
}