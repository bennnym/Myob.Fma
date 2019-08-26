using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Payslip.ExtensionMethods;
using Myob.Fma.Payslip.IncomeProcessing.Interfaces;

namespace Myob.Fma.Payslip.IncomeProcessing
{
    public class TaxTable : ITaxTable
    {
        public IList<ITaxBracket> TaxBrackets { get; private set; }

        public static TaxTable Build(params ITaxBracket[] taxBrackets)
        {
            return new TaxTable()
            {
                TaxBrackets = AddTaxBracketsIntoTaxTable(taxBrackets)
            };
        }

        private static IList<ITaxBracket> AddTaxBracketsIntoTaxTable(ITaxBracket[] brackets)
        {
            var taxBrackets = new List<ITaxBracket>();
            
            foreach (var bracket in brackets)
            {
                taxBrackets.Add(bracket);
            }

            return taxBrackets;
        }

    }
}