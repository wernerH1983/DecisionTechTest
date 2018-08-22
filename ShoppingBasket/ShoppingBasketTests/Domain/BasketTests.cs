using ShoppingBasket.Domain;
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
    }
}
