using System;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Enums;

namespace Myob.Fma.Yatzy.Scoring
{
    public class FourOfAKind : IScoringCategories    
    {
        public int GetScore(IEnumerable<IDice> roll, NumberCategory? numberCategory = null)
        {
            try
            {
                return roll.GroupBy(n => n.NumberRolled).First(g => g.Count() >= 4).Key * 4;
            }
            catch (InvalidOperationException e)
            {
                return 0;
            }
        }
    }
}