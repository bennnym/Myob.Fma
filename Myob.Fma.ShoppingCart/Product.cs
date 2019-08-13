using System;
using System.Collections.Generic;
using Myob.Fma.ShoppingCart.Enums;

namespace Myob.Fma.ShoppingCart
{
    public class Product : IProduct
    { 
        public Product(string description, string name, decimal price, int inventory = 0)
        {
            Description = description;
            Name = name;
            Price = price;
            Inventory = inventory;
            AppliedOffers = new Dictionary<Holidays, AppliedDiscount>();
        }
        
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Inventory { get; }
        public Dictionary<Holidays, AppliedDiscount> AppliedOffers { get;  }
        
        public decimal DiscountPercentage { get; private set; }

        public void UpdateOffers(Holidays holiday, AppliedDiscount discount)
        {
            if (AppliedOffers.ContainsKey(holiday))
            {
                AppliedOffers.Remove(holiday);
            }
            
            AppliedOffers.Add(holiday, discount);
        }

        public void UpdateDailyOfferDiscount(DateTime today)
        {

            var xmas = new DateTime(2019,12,24);
            var boxingDay = new DateTime(2019,12,26);
            var blackFriday = new DateTime(2019,11,29);
            var newYearsDay = new DateTime(2019,08,13);

            if (xmas.Day == today.Day && xmas.Month == today.Month)
            {
                DiscountPercentage = GetDiscount(Holidays.Christmas);
            }
            
            if (boxingDay.Day == today.Day && boxingDay.Month == today.Month)
            {
                DiscountPercentage = GetDiscount(Holidays.Christmas);
            }
            
            if (blackFriday.Day == today.Day && blackFriday.Month == today.Month)
            {
                DiscountPercentage = GetDiscount(Holidays.BlackFriday);
            }
            
            if (newYearsDay.Day == today.Day && newYearsDay.Month == today.Month)
            {
                DiscountPercentage = GetDiscount(Holidays.NewYearsDay);
            }
        }

        private int GetDiscount(Holidays holiday)
        {
            return AppliedOffers.ContainsKey(holiday) ? (int) AppliedOffers[holiday] : 0;
        }
        
    }
}