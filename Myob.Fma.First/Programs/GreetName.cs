using System;

namespace Myob.Fma.First.Programs
{
    public class GreetName
    {
        public GreetName()
        {
            Console.WriteLine("What is your name?");

            var name = Console.ReadLine().Trim();
            
            if ( String.IsNullOrWhiteSpace(name) )
                throw new ArgumentException("Name must not be blank.");

            Console.WriteLine($"Hello {name}!");
        }
    }
}