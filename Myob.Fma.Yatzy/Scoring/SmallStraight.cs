using System;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Enums;

namespace Myob.Fma.Yatzy.Scoring
{
    public class SmallStraight : IScoringCategories
    {
        public int GetScore(List<IDice> roll, NumberCategory? numberCategory = null)
        {
            try
            {
                var smallStraight = new[] {1, 2, 3, 4, 5};
                
                var isSmallStraightFound = roll
                                            .Select(n => n.NumberRolled)
                                            .OrderBy(i => i)
                                            .SequenceEqual(smallStraight);

                return isSmallStraightFound ? 15 : 0;
            }
            catch (InvalidOperationException e)
            {
                return 0;
            }
        }
    }
}