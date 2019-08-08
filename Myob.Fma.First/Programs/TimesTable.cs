using System;
using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.First.Programs
{
    public class TimesTable
    {
        public TimesTable()
        {
            var timesTableNumbers = Enumerable.Range(1, 12).ToList();

            foreach (var number in timesTableNumbers)
            {
                timesTableNumbers.ForEach(num => Console.WriteLine($"{number} x {num} = {number * num }"));
            }
        }
    }
}