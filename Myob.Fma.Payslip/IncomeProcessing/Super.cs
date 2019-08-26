using System;
using Myob.Fma.Payslip.ExtensionMethods;
using Myob.Fma.Payslip.IncomeProcessing.IncomeHelpers;
using Myob.Fma.Payslip.IncomeProcessing.Interfaces;

namespace Myob.Fma.Payslip.IncomeProcessing
{
    public class Super : ISuper
    {
        public int Amount { get; private set; }

        public static Super Generate(string superRate, IGrossIncome grossIncome)
        {
            if (string.IsNullOrWhiteSpace(superRate))
                throw new Exception("Super must be greater than 0");

            if (superRate.Contains('%'))
            {
                var indexOfPercentageSign = superRate.IndexOf('%');
                superRate = superRate.Substring(0, indexOfPercentageSign);
            }

            var superRateAsANumber = ConvertSuperStringToNumber(superRate);

            var superOverPeriod = SuperCalculator.GetSuper(superRateAsANumber, grossIncome);
            
            return new Super { Amount = superOverPeriod };
        }

        private static decimal ConvertSuperStringToNumber(string superRate)
        {
            try
            {
                return decimal.Parse(superRate);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Please enter a valid number for your super rate {e}");
                throw;
            }
        }
    }
}