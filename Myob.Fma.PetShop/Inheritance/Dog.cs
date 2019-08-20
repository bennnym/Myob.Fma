using System;

namespace Myob.Fma.PetShop.Inheritance
{
    public class Dog : Animal
    {
        public Dog(string wholeName) : base(wholeName)
        {
        }

        public override void Walk()
        {
            Console.WriteLine("I am walking (because I am a dog)");
        }

        public override void Fly()
        {
            Console.WriteLine("I can't fly (I am a dog)");
        }
    }
}