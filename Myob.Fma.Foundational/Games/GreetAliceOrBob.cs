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
            
            if (name.Substring(0,3) == "bob" || name.Substring(0,5) == "alice")
            {
                return$"Hello {name}!";
            }
            return "I can't say hello to you, sorry!";
        }
    }
}