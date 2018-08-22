using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingBasket.Domain;
using ShoppingBasketTests.Helpers;
using Xunit;

namespace ShoppingBasketTests.Domain
{
    public class OfferTests
    {

        [Fact]
        public void ShouldReturn0WhenNoBaketlines()
        {
            var sut = new Offer();
            sut.MinimalPurchases = new List<OfferLine>{ new OfferLine { Product = ProductRepositoryMock.Butter, Quantity = 2} ,new OfferLine { Product =  ProductRepositoryMock.Bread, Quantity = 1}};
            sut.Discount = ProductRepositoryMock.Bread.Price * 0.5m;

            Assert.Equal(0m, sut.CalculateDiscount(Enumerable.Empty<BasketLine>()));

        }

        [Fact]
        public void ShouldReturnCorrectDiscount()
        {
            var sut = new Offer();
            sut.MinimalPurchases = new List<OfferLine> { new OfferLine { Product = ProductRepositoryMock.Butter, Quantity = 2 }, new OfferLine { Product = ProductRepositoryMock.Bread, Quantity = 1 } };
            sut.Discount = ProductRepositoryMock.Bread.Price * 0.5m;

            Assert.Equal(0.5m, sut.CalculateDiscount(new List<BasketLine>{ new BasketLine{ Product = ProductRepositoryMock.Butter, Quantity = 2}, new BasketLine{ Product = ProductRepositoryMock.Bread, Quantity =  1}}));

        }


    }
}
