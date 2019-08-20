using System;

namespace Myob.Fma.PetShop.Composition
{
    public class Cat :  IWalk
    {
        public Cat()
        {
            
        }

        public void Fly()
        {
            Console.WriteLine("I cant fly, I am a cat");
        }

        public bool CanFly { get; set; }
        public void Walk()
        {
            throw new System.NotImplementedException();
        }

        public bool CanWalk { get; set; }
    }
}