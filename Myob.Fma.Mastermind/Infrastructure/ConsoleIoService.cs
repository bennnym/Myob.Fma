using System;

namespace Myob.Fma.Mastermind.Infrastructure
{
    public class ConsoleIoService : IConsoleDisplayService
    {
        public void DisplayOutput(string message)
        {
            Console.WriteLine(message);
        }

        public virtual string GetConsoleInput()
        {
            return Console.ReadLine();
        }
    }
}