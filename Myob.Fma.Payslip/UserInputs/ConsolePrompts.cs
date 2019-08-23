using System;

namespace Myob.Fma.Payslip.UserInputs
{
    public static class ConsolePrompts
    {
        public static string GetUserSurname()
        {
            Console.WriteLine("Please input your surname:");
            return Console.ReadLine();
        }
        
        public static string GetUserFirstName()
        {
            Console.WriteLine("Please input your name:");
            return Console.ReadLine();
        }
        
        public static string GetAnnualSalary()
        {
            Console.WriteLine("Please enter your annual salary:");
            return Console.ReadLine();
        }

        public static string GetSuperRate()
        {
            Console.WriteLine("please enter your super rate:");
            return Console.ReadLine();
        }
        
        public static string GetStartDate()
        {
            Console.WriteLine("please enter your payment start date:");
            return Console.ReadLine();
        }

        public static string GetEndDate()
        {
            Console.WriteLine("please enter your payment end date:");
            return Console.ReadLine();
        }
    }
}