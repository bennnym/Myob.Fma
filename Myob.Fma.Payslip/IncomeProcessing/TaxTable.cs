using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Payslip.ExtensionMethods;
using Myob.Fma.Payslip.IncomeProcessing.Interfaces;

namespace Myob.Fma.Payslip.IncomeProcessing
{
    public class TaxTable : ITaxTable
    {
        private readonly IList<ITaxBracket> _taxBracket = new List<ITaxBracket>();

        public TaxTable(params ITaxBracket[] taxBrackets)
        {
            AddTaxBracketsIntoTaxTable(taxBrackets);
        }

        private void AddTaxBracketsIntoTaxTable(ITaxBracket[] brackets)
        {
            foreach (var bracket in brackets)
            {
                _taxBracket.Add(bracket);
            }
        }

        public int GetTaxForPeriod(IPayPeriod payPeriod, int grossIncome)
        {
            var taxBracket = GetTaxBracket(grossIncome);

            var accumulatedTax = taxBracket.AccumulatedTaxFromPreviousBracket;
            var marginalTax = (grossIncome - taxBracket.LowerLimit) * taxBracket.MarginalTaxRate;

            var totalTax = (accumulatedTax + marginalTax) * payPeriod.GetPayPeriodAsAFractionOfAYear();

            return totalTax.Rounding();
        }

        private ITaxBracket GetTaxBracket(int annualIncome)
        {
           return _taxBracket.Single(t => annualIncome > t.LowerLimit && annualIncome <= t.UpperLimit);
        }
    }
}