using System;
using Myob.Fma.Payslip.DateProcessing;
using Myob.Fma.Payslip.ExtensionMethods;
using Myob.Fma.Payslip.IncomeProcessing.Interfaces;

namespace Myob.Fma.Payslip.IncomeProcessing
{
    public class GrossIncome : IGrossIncome
    {
        public int AnnualAmount { get; private set; }
        public int Amount { get; private set; }

        public static GrossIncome Generate(string annualIncome, IPayPeriod payPeriod)
        {
            if (string.IsNullOrWhiteSpace(annualIncome))
                throw new Exception("Annual Salary must be entered");

            var annualIncomeAsANumber = ConvertSalaryStringToNumber(annualIncome);

            var grossIncomeOverPeriod =
                (annualIncomeAsANumber * DateCalculator.GetPayPeriodAsAFractionOfAYear(payPeriod)).Rounding();
            

            return new GrossIncome
            {
                Amount = grossIncomeOverPeriod,
                AnnualAmount = annualIncomeAsANumber
            };
        }

        private static int ConvertSalaryStringToNumber(string annualIncome)
        {
            try
            {
                return int.Parse(annualIncome);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Please enter a valid number as your salary {e}");
                throw;
            }
        }
    }
}