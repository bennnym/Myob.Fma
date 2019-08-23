using System;

namespace Myob.Fma.Payslip.IncomeProcessing.Interfaces
{
    public interface IPayPeriod
    {
        DateTime Start { get; }
        DateTime End { get; }
        string GetDateString();
        decimal GetPayPeriodAsAFractionOfAYear();
    }
}