using System;
using Myob.Fma.Foundational.SumAndProductMathHelpers;
using Myob.Fma.Foundational.ValidationHelpers;

namespace Myob.Fma.Foundational.Games
{
    public class SumOrProductOfOneToN : IGame
    {
        public string Play()
        {
            var numberInput = GetNumberInput();

            var operation = GetOperationInput();

            return DetermineOperationToPerform(operation, numberInput);
        }
        
        public bool SumOrProductOperationEntered(string userInput)
        {
            return userInput != "p" && userInput != "s";
        }

        private int GetNumberInput()
        {
            Console.WriteLine("Enter any number");
            
            var inputNumber = Console.ReadLine();

            if (UserInputValidation.NumberNegativeOrInvalid(inputNumber))
            {
                Console.WriteLine("Please enter a positive number, try again:");
                GetNumberInput();
            }
            return int.Parse(inputNumber);
        }

        private string GetOperationInput()
        {
            Console.WriteLine("For the sum of all numbers from 1 to n, enter [ s ]");
            Console.WriteLine("For the product of all numbers from 1 to n, enter [ p ]");
            Console.WriteLine("enter ( s / p ) :");

            var operation = Console.ReadLine().Trim().ToLower();

            if (SumOrProductOperationEntered(operation))
            {
                Console.WriteLine("Entry must be a p or an s, try again:");
                GetOperationInput();
            }
            return operation;
        }

        private string DetermineOperationToPerform(string input, int number)
        {
            if (input == "s")
            {
                return OperationFromOneToN.Sum(number);
            }
            
            return OperationFromOneToN.Product(number);
        }
    }
}