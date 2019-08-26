using Myob.Fma.Payslip.IncomeProcessing.Interfaces;

namespace Myob.Fma.Payslip.IncomeProcessing
{
    public class TaxBracket : ITaxBracket
    {
        public decimal AccumulatedTaxFromPreviousBracket { get; private set; }
        public decimal MarginalTaxRate { get; private set; }
        public decimal LowerLimit { get; private set; }
        public decimal UpperLimit { get; private set; }
        
        public static TaxBracket Generate(decimal lowerLimit,
            decimal upperLimit, decimal accumulatedTaxFromPreviousBracket, decimal marginalTaxRate)
        {
            return new TaxBracket()
            {
                AccumulatedTaxFromPreviousBracket = accumulatedTaxFromPreviousBracket,
                MarginalTaxRate = marginalTaxRate,
                LowerLimit = AdjustLowerLimit(lowerLimit),
                UpperLimit = upperLimit,
            };
        }

        private static decimal AdjustLowerLimit(decimal lowerLimit)
        {
            return lowerLimit > 0 ? lowerLimit - 1 : 0;
        }
    }
}