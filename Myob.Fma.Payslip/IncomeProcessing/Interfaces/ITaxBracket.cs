namespace Myob.Fma.Payslip.IncomeProcessing.Interfaces
{
    public interface ITaxBracket
    {
        decimal AccumulatedTaxFromPreviousBracket { get; }
        decimal MarginalTaxRate { get; }
        decimal LowerLimit { get; }
        decimal UpperLimit { get; }
    }
}