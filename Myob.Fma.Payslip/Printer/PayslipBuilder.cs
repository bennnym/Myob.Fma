using System;
using System.Text;

namespace Myob.Fma.Payslip.Printer
{
    public static class PayslipBuilder
    {
        public static string Print(IPaySlip payslip)
        {
            var payslipOutput = new StringBuilder();

            payslipOutput.Append($"Name: {payslip.FullName}");
            payslipOutput.AppendLine();
            payslipOutput.Append($"Pay Period: {payslip.PayPeriod}");
            payslipOutput.AppendLine();
            payslipOutput.Append($"Gross Income: {payslip.GrossIncome}");
            payslipOutput.AppendLine();
            payslipOutput.Append($"Income Tax: {payslip.IncomeTax}");
            payslipOutput.AppendLine();
            payslipOutput.Append($"Net Income: {payslip.NetIncome}");
            payslipOutput.AppendLine();
            payslipOutput.Append($"Super: {payslip.Super}");

            return payslipOutput.ToString();
        }
        
    }
}