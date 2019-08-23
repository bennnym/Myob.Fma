using Myob.Fma.Payslip.IncomeProcessing.Interfaces;

namespace Myob.Fma.Payslip.IncomeProcessing
{
    public class TaxBracket : ITaxBracket
    {
        public TaxBracket(decimal lowerLimit,
            decimal upperLimit, decimal accumulatedTaxFromPreviousBracket, decimal marginalTaxRate)
        {
            AccumulatedTaxFromPreviousBracket = accumulatedTaxFromPreviousBracket;
            MarginalTaxRate = marginalTaxRate;
            LowerLimit = AdjustLowerLimit(lowerLimit);
            UpperLimit = upperLimit;
        }

        public decimal AccumulatedTaxFromPreviousBracket { get; }
        public decimal MarginalTaxRate { get; }
        public decimal LowerLimit { get; }
        public decimal UpperLimit { get; }

        private decimal AdjustLowerLimit(decimal lowerLimit)
        {
            return lowerLimit > 0 ? lowerLimit - 1 : 0;
        }
    }
}