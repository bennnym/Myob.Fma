using System;
using Myob.Fma.First.Programs;

namespace Myob.Fma.First
{
    public enum Game
    {
        HelloWorld = 1,
        GreetName, 
        GreetAliceOrBob,
        SumUpToN,
        SumToNIfMultipleOf3Or5,
        SumOrMultipleToN,
        MultiplicationTable,
        GuessingGame,
        LeapYears
    }
    
    public class GameStart
    {
        public GameStart()
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

            var selection = Console.ReadLine();

            Start(selection);

        }

        public Object Start(string gameChoice)
        {
            switch (gameChoice)
            {
                case "1":
                    return new HelloWorld();
                
                case "2":
                    return new GreetName();
                
                case "3":
                    return new GreetIfAliceOrBob();
                
                case "4":
                    return new SumToN();
                
                case "5":
                    return new SumToNIfMultipleOf3Or5();
                
                case "6":
                    return new SumOrProduct();
                
                default:
                    return new GreetName();
            }
        }
    }
}