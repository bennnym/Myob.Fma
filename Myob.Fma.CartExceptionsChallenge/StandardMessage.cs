using System;
using System.Text;

namespace Myob.Fma.CartExceptionsChallenge
{
    public static class StandardMessages
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to the Cart Builder, enter the name and price");
            Console.WriteLine("of the products you would like to add to your cart and I");
            Console.WriteLine("will tell you the cart total!");
        }

        public static bool AskIfTheyWantToContinue()
        {
            Console.WriteLine("Do you want to enter another product? (y/n)");
            var response = Console.ReadLine();

            return response.ToLower() == "y";
        }

        public static string CaptureUserData(string inputType)
        {
            AskForProductInput(inputType);
            return Console.ReadLine();
        }

        private static void AskForProductInput(string inputType)
        {
            Console.WriteLine($"Enter {inputType}:");
        }
    }
}