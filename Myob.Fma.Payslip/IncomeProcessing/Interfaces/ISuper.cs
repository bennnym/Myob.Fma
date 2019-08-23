namespace Myob.Fma.Payslip.IncomeProcessing.Interfaces
{
    public interface ISuper
    {
        decimal SuperRate { get; }
        int GetSuper(int netIncome);
    }
}