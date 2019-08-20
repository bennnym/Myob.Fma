using System;

namespace Myob.Fma.PetShop.Inheritance
{
    public abstract class Animal
    {
        public string WholeName { get; }

        public Animal(string wholeName)
        {
            WholeName = wholeName;
        }

        public virtual void Eat()
        {
            Console.WriteLine($"{WholeName} is eating...");
        }

        public virtual void Talk(string noise)
        {
            Console.WriteLine(noise);
        }

        public abstract void Walk();
        public abstract void Fly();
    }
}