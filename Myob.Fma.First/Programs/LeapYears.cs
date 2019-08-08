using System;
using System.Linq;

namespace Myob.Fma.First.Programs
{
    public class LeapYears
    {
        public LeapYears()
        {
            Console.WriteLine("The next 20 Leap Years are:");

            var currentYear = DateTime.Now.Year;

            for (var i = 0; i <= 3; i++)
            {
                var year = currentYear + i;
                
                if ( year % 4 == 0)
                {
                    var leapYearReference = Enumerable.Range(0,20).ToList();

                    leapYearReference.ForEach(count => Console.WriteLine($"{year + (count * 4)}"));
                }
            }
        }
    }
}