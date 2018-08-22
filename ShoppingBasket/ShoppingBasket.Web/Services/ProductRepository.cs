using System.Collections.Generic;
using ShoppingBasket.Domain;

namespace ShoppingBasket.Web.Services
{
    public class ProductRepository
    {
        private readonly Dictionary<string, Product> _products = new Dictionary<string, Product>
        {
            {
                "Milk", new Product
                {
                    Id = 1,
                    Name = "Milk",
                    Price = 1.15m
                }
            },
            {
                "Butter", new Product
                {
                    Id = 2,
                    Name = "Butter",
                    Price = 0.80m
                }
            },
            {
                "Bread", new Product
                {
                    Id = 3,
                    Name = "Bread",
                    Price = 1.00m
                }
            }
        };

        public Product GetByName(string name)
        {
            if (_products.ContainsKey(name))
                return _products[name];
            return null;
        }
    }
}
