using System;
using Myob.Fma.MagicYear.Extensions;

namespace Myob.Fma.MagicYear
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to the magic calculator!");
            Console.WriteLine();

            Console.WriteLine("Please input your name:");
            var firstName = Console.ReadLine();
            
            Console.WriteLine("Please input your surname:");
            var lastName = Console.ReadLine();

            Console.WriteLine("Please input your annual salary:");
            var salary = Salary(Console.ReadLine());

            Console.WriteLine("Please input your work start year:");
            var year = Year(Console.ReadLine());

            Console.WriteLine("Your magic details are:");

            var name = new Name {First = firstName, Last = lastName};
            Console.WriteLine($"Name: {name.ToString()}");
            Console.WriteLine($"Monthly Salary: {salary}");
            Console.WriteLine($"Magic Year: {year}");
        }

        static int Year(string year)
        {
            var inputValidation = int.TryParse(year, out int magicYear);
            
            if (inputValidation) return magicYear + 65;

            return 0;
        }

        static int Salary(string salary)
        {
            var inputValidation = decimal.TryParse(salary, out decimal income);
            
            if ( inputValidation ) return IntExtension.Rounding(income / 12M);

            return 0;
        }
    }
}