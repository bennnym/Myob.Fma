using System;

namespace Myob.Fma.Foundational.ValidationHelpers
{
    public static class UserInputValidation
    {
        public static bool GameSelectionCheck(string entry)
        {
            var validInput = int.TryParse(entry, out int selection);

            if (!validInput) return false;

            return selection > 0 && selection < 10;
        }

        public static bool NumberNegativeOrInvalid(string entry)
        {
            var validInput = int.TryParse(entry, out int selection);
            
            return selection < 0 || !validInput;
        }
        
    }
}