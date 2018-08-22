using System;
using System.Collections.Generic;
using System.Text;
using ShoppingBasket.Domain;

namespace ShoppingBasketTests.Helpers
{
    public static class OfferRepositoryMock
    {
        public static Offer ButterOffer => new Offer
        {
            MinimalPurchases = new List<OfferLine>
            {
                new OfferLine {Product = ProductRepositoryMock.Butter, Quantity = 2},
                new OfferLine {Product = ProductRepositoryMock.Bread, Quantity = 1}
            },
            Discount = ProductRepositoryMock.Bread.Price * 0.5m
        };

        public static Offer MilkOffer => new Offer
        {
            MinimalPurchases = new List<OfferLine>
            {
                new OfferLine {Product = ProductRepositoryMock.Milk, Quantity = 4},                
            },
            Discount = ProductRepositoryMock.Milk.Price * 0.5m
        };

    }
}
