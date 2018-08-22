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
            //Given the basket has 1 bread, 1 butter and 1 milk
            sut.AddProduct(ProductRepositoryMock.Milk, 1);
            sut.AddProduct(ProductRepositoryMock.Milk, 1);
            sut.AddProduct(ProductRepositoryMock.Bread, 1);
            sut.AddProduct(ProductRepositoryMock.Butter, 1);

            //The total should be 2.95
            Assert.Equal(4.10m, sut.Total);
        }


    }
}
