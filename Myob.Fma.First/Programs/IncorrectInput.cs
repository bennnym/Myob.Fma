using System;

namespace Myob.Fma.First.Programs
{
    public class IncorrectInput
    {
        public IncorrectInput()
        {
            Console.WriteLine("You haven't entered a correct number, try again? (y/n):");

            var tryAgain = Console.ReadLine().Trim().ToLower();

            if (tryAgain == "y") new GameStart();
        }
    }
}