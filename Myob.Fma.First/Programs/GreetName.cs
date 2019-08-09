using System;

namespace Myob.Fma.First.Programs
{
    public class GreetName : IGame 
    {
        public string Play()
        {
            Console.WriteLine("What is your name?");

            var name = Console.ReadLine().Trim();

            if (String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Sorry, I didn't recognize that input, try again.");
                this.Play();
            }
            
            return $"Hello {name}!";
        }
    }
}