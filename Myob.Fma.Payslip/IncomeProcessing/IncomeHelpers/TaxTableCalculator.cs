using System.Linq;
using Myob.Fma.Payslip.DateProcessing;
using Myob.Fma.Payslip.ExtensionMethods;
using Myob.Fma.Payslip.IncomeProcessing.Interfaces;

namespace Myob.Fma.Payslip.IncomeProcessing.IncomeHelpers
{
    public static class TaxTableCalculator
    {
        public static int GetTaxForPeriod(IPayPeriod payPeriod, IGrossIncome grossIncome, ITaxTable taxTable)
        {
            var taxBracket = GetTaxBracket(grossIncome,taxTable);

            var accumulatedTax = taxBracket.AccumulatedTaxFromPreviousBracket;
            var marginalTax = (grossIncome.AnnualAmount - taxBracket.LowerLimit) * taxBracket.MarginalTaxRate;

            var totalTax = (accumulatedTax + marginalTax) * DateCalculator.GetPayPeriodAsAFractionOfAYear(payPeriod);

            return totalTax.Rounding();
        }

        private static ITaxBracket GetTaxBracket(IGrossIncome grossIncome, ITaxTable taxTable)
        {
            return taxTable.TaxBrackets.Single(t =>
                grossIncome.AnnualAmount > t.LowerLimit && grossIncome.AnnualAmount <= t.UpperLimit);
        }
    }
}