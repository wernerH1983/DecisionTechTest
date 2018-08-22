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
            if (MinimalPurchases.TrueForAll(mp =>
                mp.Quantity > (products.SingleOrDefault(p => p.Product == mp.Product)?.Quantity ?? 0)))
                return Discount;
            return 0m;
        }
    }
}
