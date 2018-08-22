using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.Domain
{
    public class Basket
    {
        private readonly IEnumerable<Offer> _offers;

        public Basket()
        {
            _offers = Enumerable.Empty<Offer>();
        }

        public Basket(IEnumerable<Offer> offers)
        {
            _offers = offers;
        }

        private readonly List<BasketLine> _basketLines = new List<BasketLine>();

        public void AddProduct(Product product, int quantity)
        {
            _basketLines.Add(new BasketLine {Product = product, Quantity = quantity});
        }

        public decimal Total {
            get
            {
                var combinedBasketLines = _basketLines.GroupBy(bl => bl.Product.Id).Select( g => new BasketLine{ Product = g.First().Product, Quantity = g.Sum( x=> x.Quantity  )});
                return _basketLines.Sum(bl => bl.Quantity * bl.Product.Price) - _offers.Sum(
                    o => o.CalculateDiscount(combinedBasketLines));
            }
        }

}
}
