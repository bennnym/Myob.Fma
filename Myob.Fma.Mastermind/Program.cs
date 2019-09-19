using System;
using System.Reflection.Metadata;
using Myob.Fma.Mastermind.Infrastructure;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.GameServices.Input;
using Constant = Myob.Fma.Mastermind.Constants.Constant;

namespace Myob.Fma.Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleOutputService = new ConsoleIoService();

            var inputReader = new GameInput(consoleOutputService);

            inputReader.GetUsersCodeGuess();

        }
    }
}