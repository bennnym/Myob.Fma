using System.Data;
using System.Linq;

namespace Myob.Fma.GameOfLife.Validation
{
    public static class Validate
    {
        public static int ConvertStringsToNumbers(string number)
        {
            // if number is not an int or less than 1, method returns -1
            
            var validInput = int.TryParse(number, out int convertedNum);

            return validInput && convertedNum >= 1 ? convertedNum : -1;
        }

        public static bool InputIsValid(int[] inputs)
        {
            return !inputs.Contains(-1);
        }
        
        
    }
}