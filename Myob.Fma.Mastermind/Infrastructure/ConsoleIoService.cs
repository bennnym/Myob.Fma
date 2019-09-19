using System;

namespace Myob.Fma.Mastermind.Infrastructure
{
    public class ConsoleIoService : IIoService
    {
        public void DisplayOutput(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadUserInput()
        {
            return Console.ReadLine();
        }
    }
}