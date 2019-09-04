using System;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Enums;

namespace Myob.Fma.Yatzy.Scoring
{
    public class TwoPairs : IScoringCategories
    {
        public int GetScore(IEnumerable<IDice> roll, NumberCategory? numberCategory = null)
        {
            try
            {
                var numberOfPairs = roll.GroupBy(n => n.NumberRolled).Count(g => g.Count() >= 2);

                if (numberOfPairs == 2)
                {
                    return roll.GroupBy(n => n.NumberRolled).Where(g => g.Count() >= 2).Sum(x => x.Key * 2);
                }

                return 0;
            }
            catch (InvalidOperationException e)
            {
                return 0;
            }
        }
    }
}