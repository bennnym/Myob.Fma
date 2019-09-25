﻿using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Myob.Fma.Mastermind.Infrastructure;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.GameServices.Input;
using Myob.Fma.Mastermind.GameServices.Input.Processor;
using Myob.Fma.Mastermind.GameServices.Input.Validations;
using Myob.Fma.Mastermind.GameServices.Input.Validator;
using Myob.Fma.Mastermind.GameServices.Players;
using Constant = Myob.Fma.Mastermind.Constants.Constant;

namespace Myob.Fma.Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var validations = new List<IValidation>()
            {
                new ColourValidation(),
                new WordCountValidation(),
                new GuessLimitValidation()
            };
            
            var inputValidator = new InputValidator(validations);
            var consoleServices = new ConsoleIoService();
            
            var inputProcessor = new InputProcessor(consoleServices, inputValidator);

            var computerPlayer = ComputerPlayer.CreatePlayer();


        }
    }
}