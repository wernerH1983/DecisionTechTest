using System;
using System.Collections.Generic;
using System.Text;
using ShoppingBasket.Domain;

namespace ShoppingBasketTests.Helpers
{
    public static class ProductRepositoryMock
    {

        public static Product Milk => new Product
            {
                Id = 1,
                Name = "Milk",
                Price = 1.15m
            };
        

        public static Product Butter => new Product
            {
                Id = 2,
                Name = "Butter",
                Price = 0.80m
            };
        

        public static Product Bread => new Product
            {
                Id = 3,
                Name = "Bread",
                Price = 1.00m
            };
        
    }
}
