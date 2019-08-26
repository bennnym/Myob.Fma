namespace Myob.Fma.Payslip.IncomeProcessing.Interfaces
{
    public interface IGrossIncome
    {
        int Amount { get; }
        int AnnualAmount { get; }
    }
}