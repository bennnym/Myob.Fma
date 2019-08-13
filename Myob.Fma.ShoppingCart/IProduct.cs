using System;
using System.Collections.Generic;
using Myob.Fma.ShoppingCart.Enums;

namespace Myob.Fma.ShoppingCart
{
    public interface IProduct
    {
        decimal Price { get; set; }
        decimal DiscountPercentage { get; }
        string Name { get; set; }
        string Description { get; set; }
        int Inventory { get; }
        Dictionary<Holidays,AppliedDiscount> AppliedOffers{ get; }
        void UpdateDailyOfferDiscount(DateTime today);
    }
}