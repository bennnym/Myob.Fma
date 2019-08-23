namespace Myob.Fma.Payslip.IncomeProcessing.Interfaces
{
    public interface IGrossIncome
    {
        int GetGrossIncomeForPeriod(IPayPeriod payPeriod);
        int AnnualIncome { get; }
    }
}