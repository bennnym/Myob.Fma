using System;
using Myob.Fma.Payslip.EmployeeInfo;
using Myob.Fma.Payslip.ExtensionMethods;
using Myob.Fma.Payslip.IncomeProcessing;
using Myob.Fma.Payslip.UserInputs;

namespace Myob.Fma.Payslip
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNameInput = ConsolePrompts.GetUserFirstName();
            var surnameInput = ConsolePrompts.GetUserSurname();
            EmployeeDetails employeeDetails = EmployeeDetails.GenerateFullName(firstNameInput, surnameInput);

            var annualSalaryInput = ConsolePrompts.GetAnnualSalary();
            GrossIncome grossIncome = GrossIncome.GenerateGrossIncome(annualSalaryInput);

            var superRateInput = ConsolePrompts.GetSuperRate();
            Super super = Super.GenerateSuper(superRateInput);

            var startDateInput = ConsolePrompts.GetStartDate();
            var endDateInput = ConsolePrompts.GetEndDate();
            PayPeriod payPeriod = PayPeriod.GeneratePayPeriod(startDateInput, endDateInput);
            
            var bracket1 = new TaxBracket(0M, 18200M,0M,0M);
            var bracket2 = new TaxBracket(18201M, 37000M,0M,0.325M);
            var bracket3 = new TaxBracket(37001M, 87000M,3572M,0.325M);
            var bracket4 = new TaxBracket(87001M, 180000M,19822M,0.37M);
            var bracket5 = new TaxBracket(180000M, Int32.MaxValue,54232M,0.45M);
            
            var taxTable = new TaxTable(bracket1,bracket2,bracket3,bracket4,bracket5);
            
            var paySlip = new PaySlipGenerator(grossIncome,payPeriod,super,taxTable,employeeDetails);
            
            paySlip.PrintPaySlip();
//            
        }
    }
}