using System;

namespace Myob.Fma.ShoppingCart
{
    public class EventProduct : Product
    {
        public string Name { get; private set; }
        public EventProduct(string description, string name, decimal price, int inventory = 0) : base(description, name,
            price, inventory)
        {
            Name = $"event-{name}";
            
        }
        
        public DateTime StartTime  { get; set; }
        public DateTime EndTime  { get; set; }

        public string GetSession()
        {
            return $"{Name}, {StartTime.ToString()}:{EndTime.ToString()}";
        }
    }
}