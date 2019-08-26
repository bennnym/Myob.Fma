using Myob.Fma.Payslip.IncomeProcessing.Interfaces;

namespace Myob.Fma.Payslip.IncomeProcessing
{
    public class NetIncome : INetIncome
    {
        public int Amount { get; private set; }
        public static NetIncome Generate(IGrossIncome grossIncome, IncomeTax incomeTax)
        {
            return new NetIncome()
            {
                Amount = grossIncome.Amount - incomeTax.Amount
            };
        }
    }
}