using System;
using Myob.Fma.Payslip.ExtensionMethods;
using Myob.Fma.Payslip.IncomeProcessing.Interfaces;

namespace Myob.Fma.Payslip.IncomeProcessing
{
    public class Super : ISuper
    {
        public decimal SuperRate { get; private set; }

        public int GetSuper(int netIncome)
        {
            var superAmount = netIncome * (SuperRate / 100M);

            return superAmount.Rounding();
        }

        public static Super GenerateSuper(string superRate)
        {
            if (string.IsNullOrWhiteSpace(superRate))
                throw new Exception("Super must be greater than 0");

            if (superRate.Contains('%'))
            {
                var indexOfPercentageSign = superRate.IndexOf('%');
                superRate = superRate.Substring(0, indexOfPercentageSign);
            }

            var superRateAsANumber = ConvertSuperStringToNumber(superRate);
            
            return new Super { SuperRate = superRateAsANumber};
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