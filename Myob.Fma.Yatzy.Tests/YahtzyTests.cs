using System.Data;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class YahtzyTests
    {
        [Fact]
        public void Should_Return_Fifty_Only_If_All_Numbers_Are_The_Same()
        {
            // Arrange
            var rollTotal = EvaluateScore.Yatzy(1, 1, 1, 1, 1);
            // Assert
            Assert.Equal(50,rollTotal);
        }

        [Fact]
        public void Should_Return_Zero_If_All_Numbers_Are_Not_The_Same()
        {
            // Arrange
            var rollTotal = EvaluateScore.Yatzy(1, 1, 1, 2, 1);
            // Assert
            Assert.Equal(0,rollTotal);
        }


    }
}