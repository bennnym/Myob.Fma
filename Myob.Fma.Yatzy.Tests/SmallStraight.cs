using System.Collections.Generic;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class SmallStraight
    {
        [Fact]
        public void Should_Return_Sum_Of_Roll_When_A_Small_Straight_Is_Present_12345()
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
            var rollTotal = EvaluateScore.SmallStraight(roll);
            
            // Assert
            Assert.Equal(15, rollTotal);
        }
    }
}