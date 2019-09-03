using System.Collections.Generic;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class LargeStraight
    {
        [Fact]
        public void Should_Return_Sum_Of_Roll_When_A_Large_Straight_Is_Present_23456()
        {
            // Arrange
            var roll = new List<IDice>
            {
                new IDice{ ActiveSide = 2},
                new IDice{ ActiveSide = 3},
                new IDice{ ActiveSide = 4},
                new IDice{ ActiveSide = 5},
                new IDice{ ActiveSide = 6}
            };
            
            // Act
            var rollTotal = EvaluateScore.LargeStraight(roll);
            
            // Assert
            Assert.Equal(20, rollTotal);
        }
    }
}