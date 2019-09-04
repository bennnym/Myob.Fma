using System;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Enums;

namespace Myob.Fma.Yatzy.Scoring
{
    public class FullHouse : IScoringCategories
    {
        public int GetScore(List<IDice> roll, NumberCategory? numberCategory = null)
        {
            try
            {
                var groupedValues = roll.GroupBy(n => n.NumberRolled);

                var pairValue = groupedValues.First(g => g.Count<IDice>() == 2).Key * 2;
                
                var threeOfAKindValue = groupedValues.First(g => g.Count<IDice>() == 3).Key * 3;

                if (threeOfAKindValue > 0 && pairValue > 0)
                {
                    return threeOfAKindValue + pairValue;
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