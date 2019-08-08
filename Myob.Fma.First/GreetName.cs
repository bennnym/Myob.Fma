using System;

namespace Myob.Fma.First
{
    public class GreetName
    {
        public GreetName()
        {
            Console.WriteLine("What is your name?");

            var name = Console.ReadLine().Trim();
            
            if ( String.IsNullOrWhiteSpace(name) )
                throw new ArgumentNullException();

            Console.WriteLine($"Hello {name}!");
        }
    }
}