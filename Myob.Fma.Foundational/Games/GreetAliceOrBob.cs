using System;

namespace Myob.Fma.Foundational.Games
{
    public class GreetAliceOrBob : IGame
    {
        public string Play()
        {
            Console.WriteLine("What is your first name? I only say hello if your name is either Alice or Bob!!");

            var name = Console.ReadLine().ToLower().Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please try again and enter a valid name:");
                Play();
            }

            return CheckForAliceOrBob(name);
        }

        public string CheckForAliceOrBob(string name)
        {
            if (name.Length == 3 && name == "bob" || name.Length == 5 && name == "alice")
            {
                return$"Hello {name}!";
            }

            return "I can't say hello to you, sorry!";
        }
    }
}