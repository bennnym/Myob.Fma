using System;
using System.Collections.Generic;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Scoring;
using Xunit;

namespace Myob.Fma.Yatzy
{
    public class ChanceTests
    {
        private readonly Dice _sideOne;
        private readonly Dice _sideTwo;
        private readonly Dice _sideThree;
        private readonly Dice _sideFour;
        private readonly Dice _sideFive;
        private readonly Dice _sideSix;

        public ChanceTests()
        {
            _sideOne = new Dice() {NumberRolled = 1};
            _sideTwo = new Dice() {NumberRolled = 2};
            _sideThree = new Dice() {NumberRolled = 3};
            _sideFour = new Dice() {NumberRolled = 4};
            _sideFive = new Dice() {NumberRolled = 5};
            _sideSix = new Dice() {NumberRolled = 6};
        }

        [Fact]
        public void Should_Return_Sum_Of_All_Active_Sides_In_Roll()
        {
            var roll = new List<IDice>
            {
                _sideOne,
                _sideOne, 
                _sideThree, 
                _sideThree,
                _sideSix
            };
            
            var chanceCategory = new Chance();

            var rollTotal = chanceCategory.GetScore(roll);
            
            Assert.Equal(14,rollTotal);

        }
    }
}