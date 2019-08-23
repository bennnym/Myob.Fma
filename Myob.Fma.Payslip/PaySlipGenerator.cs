using System;
using Myob.Fma.Payslip.EmployeeInfo.Interfaces;
using Myob.Fma.Payslip.IncomeProcessing.Interfaces;

namespace Myob.Fma.Payslip
{
    public class PaySlipGenerator
    {
        private readonly IGrossIncome _grossIncome;

        private decimal _netIncome =>
            _grossIncome.GetGrossIncomeForPeriod(_payPeriod) -
            _taxTable.GetTaxForPeriod(_payPeriod, _grossIncome.AnnualIncome);

        private readonly IPayPeriod _payPeriod;
        private readonly ISuper _superRate;
        private readonly ITaxTable _taxTable;
        private readonly IEmployeeDetails _employeeDetails;

        public PaySlipGenerator(IGrossIncome grossIncome, IPayPeriod payPeriod, ISuper superRate, ITaxTable taxTable, IEmployeeDetails employeeDetails)
        {
            _grossIncome = grossIncome;
            _payPeriod = payPeriod;
            _superRate = superRate;
            _taxTable = taxTable;
            _employeeDetails = employeeDetails;
        }

        public void PrintPaySlip()
        {
            var grossIncome = _grossIncome.GetGrossIncomeForPeriod(_payPeriod);

            Console.WriteLine($"Name: {_employeeDetails.GetFullName()}");
            Console.WriteLine($"Pay Period: {_payPeriod.GetDateString()}");
            Console.WriteLine($"Gross Income: {grossIncome}");
            Console.WriteLine($"Income Tax: {_taxTable.GetTaxForPeriod(_payPeriod,_grossIncome.AnnualIncome)}");
            Console.WriteLine($"Net Income: {_netIncome}");
            Console.WriteLine($"Super: {_superRate.GetSuper(grossIncome)}");
        }
    }
}