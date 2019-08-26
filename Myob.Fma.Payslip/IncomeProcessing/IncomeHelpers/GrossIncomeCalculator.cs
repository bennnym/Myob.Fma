//using Myob.Fma.Payslip.DateProcessing;
//using Myob.Fma.Payslip.ExtensionMethods;
//using Myob.Fma.Payslip.IncomeProcessing.Interfaces;
//
//namespace Myob.Fma.Payslip.IncomeProcessing.IncomeHelpers
//{
//    public static class GrossIncomeCalculator
//    {
//        public static int GetIncomeForPeriod(IPayPeriod payPeriod, GrossIncome grossIncome)
//        {
//            var incomeOverPeriod = grossIncome.AnnualIncome * DateCalculator.GetPayPeriodAsAFractionOfAYear(payPeriod);
//
//            return incomeOverPeriod.Rounding();
//        }
//    }
//}