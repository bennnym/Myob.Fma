using Myob.Fma.Payslip.ExtensionMethods;
using Myob.Fma.Payslip.IncomeProcessing.Interfaces;

namespace Myob.Fma.Payslip.IncomeProcessing.IncomeHelpers
{
    public static class SuperCalculator
    {
        public static int GetSuper(decimal superRate, IGrossIncome grossIncome)
        {
            var superAmount = grossIncome.Amount * (superRate / 100M);

            return superAmount.Rounding();
        }
    }
}