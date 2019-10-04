using System.Collections.Generic;
using Myob.Fma.Mastermind.GameServices.Counter;
using Myob.Fma.Mastermind.Infrastructure;
using Myob.Fma.Mastermind.GameServices.Input.Processor;
using Myob.Fma.Mastermind.GameServices.Input.Validations;
using Myob.Fma.Mastermind.GameServices.Input.Validations.InputValidations;
using Myob.Fma.Mastermind.GameServices.Input.Validator;
using Myob.Fma.Mastermind.GameServices.Players;

namespace Myob.Fma.Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var validations = new List<IValidation>()
            {
                new WordCountValidation(),
                new ColourValidation()
            };

            var validator = new InputValidator(validations);
            var consoleService = new ConsoleIoService();
            
            var inputProcessor = new InputProcessor(consoleService, validator);
            
            var computerPlayer = new ComputerPlayer();
            var guessCounter = new GuessCounter(consoleService);
            var game = new Game(computerPlayer, guessCounter);
            
            var gameEngine = new GameEngine(inputProcessor, consoleService);
            
            gameEngine.Mastermind(game); // method should be a verb!
        }
        
    }
}