using System;
using Myob.Fma.Payslip.DateProcessing;
using Myob.Fma.Payslip.EmployeeInfo;
using Myob.Fma.Payslip.ExtensionMethods;
using Myob.Fma.Payslip.IncomeProcessing;
using Myob.Fma.Payslip.Printer;
using Myob.Fma.Payslip.UserInputs;

namespace Myob.Fma.Payslip
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNameInput = StandardMessage.CaptureData("first name");
            var surnameInput = StandardMessage.CaptureData("surname");

            var annualSalaryInput = StandardMessage.CaptureData("annual salary");

            var superRateInput = StandardMessage.CaptureData("super rate");

            var startDate = StandardMessage.CaptureData("payment start date");
            var endDate = StandardMessage.CaptureData("payment end date");

            var bracket1 = TaxBracket.Generate(0M, 18200M, 0M, 0M);
            var bracket2 = TaxBracket.Generate(18201M, 37000M, 0M, 0.325M);
            var bracket3 = TaxBracket.Generate(37001M, 87000M, 3572M, 0.325M);
            var bracket4 = TaxBracket.Generate(87001M, 180000M, 19822M, 0.37M);
            var bracket5 = TaxBracket.Generate(180000M, Int32.MaxValue, 54232M, 0.45M);

            var taxTable = TaxTable.Build(bracket1, bracket2, bracket3, bracket4, bracket5);

            EmployeeDetails employeeDetails = EmployeeDetails.ConstructFullName(firstNameInput, surnameInput);

            PayPeriod payPeriod = PayPeriod.Generate(startDate, endDate);

            GrossIncome grossIncome = GrossIncome.Generate(annualSalaryInput, payPeriod);
            IncomeTax incomeTax = IncomeTax.Generate(taxTable, grossIncome, payPeriod);
            NetIncome netIncome = NetIncome.Generate(grossIncome, incomeTax);

            Super super = Super.Generate(superRateInput, grossIncome);

            var paySlip = PaySlip.Create(
                employeeDetails,
                payPeriod,
                grossIncome,
                incomeTax,
                netIncome,
                super
            );

            var payslipOutput = PayslipPrinter.Print(paySlip);

            Console.WriteLine(payslipOutput);
//            
        }
    }
}