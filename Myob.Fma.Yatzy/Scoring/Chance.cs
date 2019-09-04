using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Enums;

namespace Myob.Fma.Yatzy.Scoring
{
    public class Chance : IScoringCategories
    {
        public int GetScore(IEnumerable<IDice> roll, NumberCategory? numberCategory = null)
        {
            return roll.Sum(d => d.NumberRolled);
        }
    }
}