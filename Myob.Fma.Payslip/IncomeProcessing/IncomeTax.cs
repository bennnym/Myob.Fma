using Myob.Fma.Payslip.IncomeProcessing.IncomeHelpers;
using Myob.Fma.Payslip.IncomeProcessing.Interfaces;

namespace Myob.Fma.Payslip.IncomeProcessing
{
    public class IncomeTax : IIncomeTax
    {
        public int Amount { get; private set; }

        public static IncomeTax Generate(ITaxTable taxTable, IGrossIncome grossIncome, IPayPeriod payPeriod)
        {
            return new IncomeTax()
            {
                Amount = TaxTableCalculator.GetTaxForPeriod(payPeriod, grossIncome, taxTable)
            };
        }
    }
}