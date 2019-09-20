using System;
using System.Reflection.Metadata;
using Myob.Fma.Mastermind.Infrastructure;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.GameServices.Input;
using Myob.Fma.Mastermind.Utilities;
using Constant = Myob.Fma.Mastermind.Constants.Constant;

namespace Myob.Fma.Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleServices = new ConsoleIoService();
            var patternValidator = new PatternValidator();

            var inputReader = new GameInput(consoleServices, patternValidator);

            inputReader.GetUsersCodeGuess();

        }
    }
}