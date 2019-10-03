using System;

namespace Myob.Fma.Mastermind.Infrastructure
{
    public class ConsoleIoService : IConsoleDisplayService
    {
        public void DisplayOutput(string message)
        {
            Console.WriteLine(message);
        }

        public string GetConsoleInput()
        {
            return Console.ReadLine();
        }

        public void ExitApplication() // move this to guess limit validations?
        {
            Environment.Exit(0); // bound to console - add to its class
        }
    }
}