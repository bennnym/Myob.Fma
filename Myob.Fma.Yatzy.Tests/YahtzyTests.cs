using System;
using System.Collections.Generic;
using System.Data;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Scoring;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class YahtzyTests
    {
        private Scoring.YatzyCategory _yatzyCategory;

        public YahtzyTests()
        {
            _yatzyCategory = new YatzyCategory();
        }
        [Fact]
        public void Should_Return_Fifty_Only_If_All_Numbers_Are_The_Same()
        {
            // Arrange
            var roll = new List<IDice>
            {
                new Dice {NumberRolled = 1},
                new Dice {NumberRolled = 1},
                new Dice {NumberRolled = 1},
                new Dice {NumberRolled = 1},
                new Dice {NumberRolled = 1}
            };
            
            var rollTotal = _yatzyCategory.GetScore(roll);
            
            // Assert
            
            Assert.Equal(50,rollTotal);
        }

        [Fact]
        public void Should_Return_Zero_If_All_Numbers_Are_Not_The_Same()
        {
            // Arrange
            var roll = new List<IDice>
            {
                new Dice {NumberRolled = 1},
                new Dice {NumberRolled = 1},
                new Dice {NumberRolled = 2},
                new Dice {NumberRolled = 1},
                new Dice {NumberRolled = 1}
            };
            
            // Act
            var rollTotal = _yatzyCategory.GetScore(roll);
            
            // Assert
            Assert.Equal(0, rollTotal);
        }


    }
}