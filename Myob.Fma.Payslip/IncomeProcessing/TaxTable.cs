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
                TaxBrackets = taxBrackets.ToList()
            };
        }
    }
}