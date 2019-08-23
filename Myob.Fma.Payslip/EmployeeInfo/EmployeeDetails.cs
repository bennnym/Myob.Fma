using System;
using Myob.Fma.Payslip.EmployeeInfo.Interfaces;

namespace Myob.Fma.Payslip.EmployeeInfo
{
    public class EmployeeDetails : IEmployeeDetails
    {
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        
        public static EmployeeDetails GenerateFullName(string firstName, string surname)
        {
            if ( string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(surname))
                throw new Exception("Name and surname must not be blank");

            return new EmployeeDetails {FirstName = firstName, Surname = surname};
        }

        public string GetFullName()
        {
            return $"{FirstName} {Surname}";
        }
    }
}