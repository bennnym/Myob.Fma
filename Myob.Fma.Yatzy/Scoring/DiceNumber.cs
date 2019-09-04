using System.Collections.Generic;
using System.Data;
using System.Linq;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Enums;

namespace Myob.Fma.Yatzy.Scoring
{
    public class DiceNumber : IScoringCategories
    {
        public int GetScore(IEnumerable<IDice> roll, NumberCategory? numberCategory = null)
        {
            if (numberCategory == null)
                throw new NoNullAllowedException("A number category must be entered as an argument.");

            var diceNumberToSum = (int) numberCategory;

            return roll
                .Where(d => d.NumberRolled == diceNumberToSum)
                .Aggregate(0, (sum, dice) => sum + dice.NumberRolled);
        }
    }
}