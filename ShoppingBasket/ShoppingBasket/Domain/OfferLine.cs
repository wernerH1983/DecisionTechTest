using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Domain
{
    public class OfferLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
