using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Enums;

namespace Myob.Fma.Yatzy.Scoring
{
    public class YatzyCategory : IScoringCategories
    {
        public int GetScore(IEnumerable<IDice> roll, NumberCategory? numberCategory = null)
        {
            var uniqueDieNumbers = roll.GroupBy(d => d.NumberRolled).Count();

            return uniqueDieNumbers == 1 ? 50 : 0;
        }
    }
}