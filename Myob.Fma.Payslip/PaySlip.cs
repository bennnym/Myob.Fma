using System;
using Myob.Fma.Payslip.DateProcessing;
using Myob.Fma.Payslip.EmployeeInfo.Interfaces;
using Myob.Fma.Payslip.IncomeProcessing;
using Myob.Fma.Payslip.IncomeProcessing.Interfaces;
using Myob.Fma.Payslip.EmployeeInfo;

namespace Myob.Fma.Payslip
{
    public class PaySlip : IPaySlip
    {
        public string FullName { get; private set; }
        public string PayPeriod { get; private set; }
        public int GrossIncome { get; private set; }
        public int IncomeTax { get; private set; }
        public int NetIncome { get; private set; }
        public int Super { get; private set; }

        public static PaySlip Create(IEmployeeDetails employeeDetails, IPayPeriod payPeriod, IGrossIncome grossIncome,
            IIncomeTax incomeTax, INetIncome netIncome, ISuper super)
        {
            return new PaySlip()
            {
                FullName = FullNameBuilder.Combine(employeeDetails),
                PayPeriod = DateCalculator.GetDateString(payPeriod),
                GrossIncome = grossIncome.Amount,
                IncomeTax = incomeTax.Amount,
                NetIncome = netIncome.Amount,
                Super = super.Amount
            };
        }
    }
}