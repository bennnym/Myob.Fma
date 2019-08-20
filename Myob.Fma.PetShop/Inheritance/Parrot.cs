using System;

namespace Myob.Fma.PetShop.Inheritance
{
    public class Parrot : Animal
    {
        public Parrot(string wholeName) : base(wholeName)
        {
        }

        public override void Walk()
        {
            Console.WriteLine("I am a walking parrot");
        }

        public override void Fly()
        {
            Console.WriteLine("I am a flying parrot");
        }
    }
}