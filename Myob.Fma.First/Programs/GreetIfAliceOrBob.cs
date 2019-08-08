using System;

namespace Myob.Fma.First.Programs

{
    public class GreetIfAliceOrBob
    {
        public GreetIfAliceOrBob()
        {
            Console.WriteLine("What is your first name? I only say hello if your name is either Alice or Bob!!");

            var name = Console.ReadLine().ToLower().Trim();
            
            if ( String.IsNullOrWhiteSpace(name) ) throw new ArgumentException("name must not be blank.");

            if (name.Substring(0,5) == "alice" || name.Substring(0,3) == "bob")
            {
                Console.WriteLine($"Hello {name}!");
            }
            else
            {
                Console.WriteLine("I can't say hello to you, sorry!");
            }
        }
    }
}