using System.Collections.Generic;

namespace Myob.Fma.Payslip.IncomeProcessing.Interfaces
{
    public interface ITaxTable
    {
        IList<ITaxBracket> TaxBrackets { get; }
    }
}