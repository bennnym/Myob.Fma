using System.Collections.Generic;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Enums;

namespace Myob.Fma.Yatzy.Scoring
{
    public interface IScoringCategories
    {
        int GetScore(IEnumerable<IDice> roll, NumberCategory? numberCategory = null);
    }
}