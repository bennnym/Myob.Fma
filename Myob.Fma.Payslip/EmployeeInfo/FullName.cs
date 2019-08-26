using Myob.Fma.Payslip.EmployeeInfo.Interfaces;

namespace Myob.Fma.Payslip.EmployeeInfo
{
    public static class FullNameBuilder
    {
        public static string Combine(IEmployeeDetails employeeDetails)
        {
            return $"{employeeDetails.FirstName} {employeeDetails.Surname}";
        }
    }
}