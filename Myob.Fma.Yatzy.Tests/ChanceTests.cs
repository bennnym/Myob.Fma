using System;
using System.Collections.Generic;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Scoring;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class ChanceTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Should_Return_Sum_Of_All_Active_Sides_In_Roll(List<IDice> roll, int expectedOutput )
        {
            var chanceCategory = new Chance();

            var rollTotal = chanceCategory.GetScore(roll);
            
            Assert.Equal(expectedOutput,rollTotal);

        }
        
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { new List<IDice>
                {
                    new Dice() {NumberRolled = 1},
                    new Dice() {NumberRolled = 3},
                    new Dice() {NumberRolled = 5},
                    new Dice() {NumberRolled = 4},
                    new Dice() {NumberRolled = 1},
                }, 14},
                
                new object[] { new List<IDice>
                {
                    new Dice() {NumberRolled = 3},
                    new Dice() {NumberRolled = 3},
                    new Dice() {NumberRolled = 6},
                    new Dice() {NumberRolled = 4},
                    new Dice() {NumberRolled = 1},
                }, 17}
                    
            };
    }
}