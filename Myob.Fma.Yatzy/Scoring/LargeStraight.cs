using System;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Enums;

namespace Myob.Fma.Yatzy.Scoring
{
    public class LargeStraight : IScoringCategories
    {
        public int GetScore(List<IDice> roll, NumberCategory? numberCategory = null)
        {
            try
            {
                var largeStraight = new[] {2, 3, 4, 5, 6};
                var isLargeStraightFound =
                    roll
                        .Select(d => d.NumberRolled)
                        .OrderBy(n => n)
                        .SequenceEqual(largeStraight);

                return isLargeStraightFound ? 20 : 0;
            }
            catch (InvalidOperationException e)
            {
                return 0;
            }
        }
    }
}