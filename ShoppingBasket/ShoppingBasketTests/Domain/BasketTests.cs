using System.Collections.Generic;
using ShoppingBasket.Domain;
using ShoppingBasketTests.Helpers;
using Xunit;

namespace ShoppingBasketTests.Domain
{
    public class BasketTests
    {
        [Fact]
        public void WhenNoProductsAdded_BasketShouldReturn0AsTotal()
        {
            var sut = new Basket();
            Assert.Equal(0m, sut.Total);
        }

        [Fact]
        public void WhenProductsAreAdded_BasketShouldCalculateCorrectPrice()
        {
            var sut = new Basket();
            //Given the basket has 1 bread, 1 butter and 1 milk
            sut.AddProduct(ProductRepositoryMock.Milk, 1);
            sut.AddProduct(ProductRepositoryMock.Bread, 1);
            sut.AddProduct(ProductRepositoryMock.Butter, 1);

            //The total should be 2.95
            Assert.Equal(2.95m, sut.Total);
        }

        [Fact]
        public void WhenSameProductIsAddedMultipeTimes_BasketShouldCalculateCorrectPrice()
        {
            var sut = new Basket();
            //Given the basket has 1 bread, 1 butter,  1 milk and 1 milk
            sut.AddProduct(ProductRepositoryMock.Milk, 1);
            sut.AddProduct(ProductRepositoryMock.Milk, 1);
            sut.AddProduct(ProductRepositoryMock.Bread, 1);
            sut.AddProduct(ProductRepositoryMock.Butter, 1);

            //The total should be 4.10
            Assert.Equal(4.10m, sut.Total);
        }

        [Fact]
        public void When2ButterAnd2BreadAreInTheBasket_BasketShouldReturnCorrectPrice()
        {
            var sut = new Basket(new List<Offer>{OfferRepositoryMock.ButterOffer});
            //Given the basket has 2 butter and 2 bread 
            sut.AddProduct(ProductRepositoryMock.Butter,2);
            sut.AddProduct(ProductRepositoryMock.Bread,2);

            //The total should be 3.10  
            Assert.Equal(3.10m, sut.Total);
        }

        [Fact]
        public void When4MilkAreInTheBasket_BasketShouldApplyDiscountAndReturnCorrectPrice()
        {
            var sut = new Basket(new List<Offer>{OfferRepositoryMock.ButterOffer, OfferRepositoryMock.MilkOffer});
            //Given the basket has 4 Milk
            sut.AddProduct(ProductRepositoryMock.Milk, 4);
            //The total should be 3.45
            Assert.Equal(3.45m, sut.Total);
        }

        [Fact]
        public void WhenMultipelApply_BasketShouldApplyMultipleDiscounts()
        {
            var sut = new Basket(new List<Offer> { OfferRepositoryMock.ButterOffer, OfferRepositoryMock.MilkOffer });
            //Given the basket has 2 butter, 1 bread and 8 milk
            sut.AddProduct(ProductRepositoryMock.Butter,2);
            sut.AddProduct(ProductRepositoryMock.Bread,1);
            sut.AddProduct(ProductRepositoryMock.Milk,8);
            //the total should be £9.00
            Assert.Equal(9m, sut.Total);
        }

        [Fact]
        public void WhenProductsAddedMultipleTimes_DiscountIsCalculatedCorrectly()
        {
            var sut = new Basket(new List<Offer> { OfferRepositoryMock.ButterOffer, OfferRepositoryMock.MilkOffer });
            //Given the basket contains 4 milk
            sut.AddProduct(ProductRepositoryMock.Milk, 1);
            sut.AddProduct(ProductRepositoryMock.Milk, 1);
            sut.AddProduct(ProductRepositoryMock.Milk, 1);
            sut.AddProduct(ProductRepositoryMock.Milk, 1);
            //The total should be 3.45
            Assert.Equal(3.45m, sut.Total);
        }
    }
}
