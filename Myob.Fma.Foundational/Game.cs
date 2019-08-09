using System;
using Myob.Fma.Foundational.Games;
using Myob.Fma.Foundational.ValidationHelpers;

namespace Myob.Fma.Foundational
{
    public class Game
    {
        public void Intro()
        {
            Console.WriteLine("Welcome to the Basic Coding Katas, please select a problem to execute below:");
            Console.WriteLine("[1] Write a program that prints ‘Hello World’ to the screen.");
            Console.WriteLine("[2] Write a program that asks the user for their name and greets them with their name.");
            Console.WriteLine("[3] Write a program that asks the user for their name and only greets you if you are Alice or Bob.");
            Console.WriteLine("[4] Write a program that asks the user for a number n and prints the sum of the numbers 1 to n");
            Console.WriteLine("[5] Write a program that asks the user for a number n and prints the sum of the numbers 1 to n if the number is a multiple of three or five, e.g. 3, 5, 6, 9, 10, 12, 15 for n=17");
            Console.WriteLine("[6] Write a program that asks the user for a number n and gives them the possibility to choose between computing the sum and computing the product of 1,…,n.");
            Console.WriteLine("[7] Write a program that prints a multiplication table for numbers up to 12.");
            Console.WriteLine("[8] Write a guessing game where the user has to guess a secret number. ");
            Console.WriteLine("After every guess the program tells the user whether their number was too large or too small.");
            Console.WriteLine("At the end the number of tries needed should be printed. It counts only as one try if they input the same number multiple times consecutively.");
            Console.WriteLine("[9] Write a program that prints the next 20 leap years.");
            
        }

        public int GetUserGameSelection()
        {
            var gameSelection = Console.ReadLine();
            
            var validInput = UserInputValidation.GameSelectionCheck(gameSelection);

            if (!validInput)
            {
                Console.WriteLine("Please enter a valid number, try again:");
                return GetUserGameSelection();
            }
            
            return int.Parse(gameSelection);
        }

        public IGame Start(int selection)
        {

            switch (selection)
            {
                case 1:
                    return new HelloWorld();

                case 2:
                    return new GreetName();

                case 3:
                   return new GreetAliceOrBob();

                case 4:
                    return new SumNumbersFromOneToN();

                case 5:
                    return new SumIfMultiplesOf3Or5();

                case 6:
                    return new SumOrProductOfOneToN();

                case 7:
                    return new TimesTable();
                
                case 8:
                    return new GuessingGame();
                
                default:
                    return new LeapYears();
            }
        }

        public bool PlayAgain()
        {
            Console.WriteLine("Would you like to play again? (y/n)");
            
            var answer = Console.ReadLine().ToLower().Trim();

            if (answer == "y")
            {
                return true;
            }

            if (answer == "n")
            {
                return false;
            }

            Console.WriteLine("Please enter y or n");
            return PlayAgain();
        }
        
        
        
        
    }
}