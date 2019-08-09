using System;

namespace Myob.Fma.Foundational.Games
{
    public class LeapYears : IGame
    {
        private readonly int _currentYear;
        
        public LeapYears()
        {
            _currentYear = DateTime.Now.Year;
        }
        
        public string Play()
        {
            return OutPutwentyLeapYears(_currentYear);
        }

        private string OutPutwentyLeapYears(int year, int found = 0)
        {
            if (found == 19 && year % 4 == 0)
            {
                return year.ToString();
            }

            if (year % 4 == 0)
            {
                return $"{year.ToString()}, {OutPutwentyLeapYears(year + 1, found + 1)}";
            }

            return OutPutwentyLeapYears(year + 1, found);
        }
    }
}