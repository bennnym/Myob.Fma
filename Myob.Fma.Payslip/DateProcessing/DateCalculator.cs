using Myob.Fma.Payslip.IncomeProcessing.Interfaces;

namespace Myob.Fma.Payslip.DateProcessing
{
    public static class DateCalculator
    {
        public static string GetDateString(IPayPeriod payPeriod)
        {
            return payPeriod.Start.ToString("M") + " - " + payPeriod.End.ToString("M");
        }
        
        public static decimal GetPayPeriodAsAFractionOfAYear(IPayPeriod payPeriod)
        {
            var differenceOfDays = (payPeriod.End - payPeriod.Start).TotalDays;

            return (decimal)differenceOfDays / 365M;
        }
    }
}