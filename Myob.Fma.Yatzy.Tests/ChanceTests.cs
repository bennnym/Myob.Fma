using System;
using System.Collections.Generic;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class ChanceTests
    {
        [Theory]
        [InlineData(new List <IDice>{new IDice(){ActiveSide = 1}, new IDice(){ActiveSide = 1},new IDice(){ActiveSide = 3},new IDice(){ActiveSide = 3},new IDice(){ActiveSide = 6}},14)]
        [InlineData(new List <IDice>{new IDice(){ActiveSide = 4}, new IDice(){ActiveSide = 5},new IDice(){ActiveSide = 5},new IDice(){ActiveSide = 6},new IDice(){ActiveSide = 1}},21)]
        public void Should_Return_Sum_Of_All_Active_Sides_In_Roll(List<IDice> roll, int expectedOutput)
        {
            //Arrange
            var rollTotal = EvaluateScore.Chance(roll);
            //Assert
            Assert.Equal(expectedOutput,rollTotal);
        }
    }
}