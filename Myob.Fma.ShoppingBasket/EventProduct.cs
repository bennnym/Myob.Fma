using System;

namespace Myob.Fma.ShoppingBasket
{
    public class EventProduct : Product
    {
        
        public EventProduct(string productType, string brand, decimal price, int quantity) : base(productType, brand,
            price, quantity)
        {
            StartTime = DateTime.Now;
            ProductType = $"event-{productType} start time: {StartTime} end time: {EndTime}";
        }
        
        public override string ProductType { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime => StartTime.AddMinutes(120);
    }
}