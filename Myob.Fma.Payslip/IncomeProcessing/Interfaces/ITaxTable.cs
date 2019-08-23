using System.Collections.Generic;

namespace Myob.Fma.Payslip.IncomeProcessing.Interfaces
{
    public interface ITaxTable
    {
        int GetTaxForPeriod(IPayPeriod payPeriod,int grossIncome);
    }
}