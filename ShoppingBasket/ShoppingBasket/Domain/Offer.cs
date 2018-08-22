using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.Domain
{
    public class Offer
    {
        public List<OfferLine> MinimalPurchases { get; set; }
        public decimal Discount { get; set; }

        public decimal CalculateDiscount(IEnumerable<BasketLine> products)
        {
            var minimalPurchaseMet = MinimalPurchases.Select(mp =>
                (products.SingleOrDefault(p => p.Product.Id == mp.Product.Id)?.Quantity ?? 0) / mp.Quantity).Min();

            return minimalPurchaseMet * Discount;

        }
    }
}
