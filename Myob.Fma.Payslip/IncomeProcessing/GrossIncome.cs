using System;
using Myob.Fma.Payslip.ExtensionMethods;
using Myob.Fma.Payslip.IncomeProcessing.Interfaces;

namespace Myob.Fma.Payslip.IncomeProcessing
{
    public class GrossIncome : IGrossIncome
    {
        public int AnnualIncome { get; private set; }

        public static GrossIncome GenerateGrossIncome(string annualIncome)
        {
            if (string.IsNullOrWhiteSpace(annualIncome))
                throw new Exception("Annual Salary must be entered");

            var annualIncomeAsANumber = ConvertSalaryStringToNumber(annualIncome);

            return new GrossIncome {AnnualIncome = annualIncomeAsANumber};
        }

        public int GetGrossIncomeForPeriod(IPayPeriod payPeriod)
        {
            var incomeOverPeriod = AnnualIncome * payPeriod.GetPayPeriodAsAFractionOfAYear();

            return incomeOverPeriod.Rounding();
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