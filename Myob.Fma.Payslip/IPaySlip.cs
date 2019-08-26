namespace Myob.Fma.Payslip
{
    public interface IPaySlip
    {
        string FullName { get; }
        string PayPeriod { get; }
        int GrossIncome { get; }
        int IncomeTax { get; }
        int NetIncome { get; }
        int Super { get; }
    }
}