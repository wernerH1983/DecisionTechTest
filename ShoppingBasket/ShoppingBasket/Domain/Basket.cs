using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.Domain
{
    public class Basket
    {
        private readonly List<BasketLine> _basketLines = new List<BasketLine>();
        
        public void AddProduct(Product product, int quantity)
        {
            _basketLines.Add(new BasketLine { Product = product, Quantity = quantity});            
        }

        public decimal Total => _basketLines.Sum(bl => bl.Quantity * bl.Product.Price);



    }
}
