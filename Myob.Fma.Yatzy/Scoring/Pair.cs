using System;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Enums;

namespace Myob.Fma.Yatzy.Scoring
{
    public class Pair : IScoringCategories
    {
        public int GetScore(List<IDice> roll, NumberCategory? numberCategory = null)
        {
            try
            {
                return roll
                    .GroupBy(n => n.NumberRolled)
                    .Where(g => g.Count() >= 2)
                    .OrderByDescending(g => g.First().NumberRolled).First().Key * 2;
            }
            catch (InvalidOperationException e)
            {
                return 0;
            }
        }
    }
}