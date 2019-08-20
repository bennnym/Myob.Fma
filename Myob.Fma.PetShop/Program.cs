using System;
using System.Collections.Generic;
using Myob.Fma.PetShop.Composition;
using Dog = Myob.Fma.PetShop.Inheritance.Dog;
using Parrot = Myob.Fma.PetShop.Inheritance.Parrot;

namespace Myob.Fma.PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog("Lassie");
            
            dog.Fly();
            
            dog.Walk();
            
            dog.Eat();
            
            dog.Talk("woof woof");

            Console.WriteLine("-----------");
            
            var parrot = new Parrot("smokey");
            
            parrot.Fly();
            parrot.Walk();
            parrot.Eat();
            parrot.Talk("yak");


            var walkers = new List<IWalk>();
            walkers.Add(new Cat());
            walkers.Add(new Horse());
            walkers.Add(new Cat());

            foreach (var animal in walkers)
            {
                animal.Walk();
            }
            
        }
    }
}