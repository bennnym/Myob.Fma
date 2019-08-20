using System.Collections.Generic;

namespace Myob.Fma.PetShop.Composition
{
    public class Parrot
    {
        private List<Leg> _legs;
        private List<Wing> _wings;
        
        private readonly string _wholeName;

        public Parrot(string wholeName)
        {
            _wholeName = wholeName;
            _legs = new List<Leg>()
            {
                new Leg(),
                new Leg()
            };

            _wings = new List<Wing>()
            {
                new Wing(),
                new Wing()
            };
        }


        public void Walk()
        {
            _legs.ForEach(l => l.Walk());
        }

        public void Fly()
        {
            _wings.ForEach(w => w.Fly());
        }
        
    }
}