using System.Collections.Generic;

namespace Myob.Fma.PetShop.Composition
{
    public class Dog
    {
        private readonly List<Leg> _leg;
        public string Name { get; }

        
        
        public Dog(string name)
        {
            Name = name;
            _leg = new List<Leg>()
            {
                new Leg(),
                new Leg(),
                new Leg(),
                new Leg()
            };
        }


        public void Walk()
        {
            _leg.ForEach(l => l.Walk());
        }
        
        public void Run()
        {
            _leg.ForEach(l => l.Run());
        }

        
    }
}