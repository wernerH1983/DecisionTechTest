using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasket.Web.Models
{
    public class Order
    {
        public int Milk { get; set; }
        public int Butter { get; set; }
        public int Bread { get; set; }
        public decimal? Total { get; set; }
    }
}
