using Microsoft.AspNetCore.Mvc;
using ShoppingBasket.Web.Models;
using ShoppingBasket.Web.Services;

namespace ShoppingBasket.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly BasketFactory _basketFactory;
        
        public BasketController(ProductRepository productRepository, BasketFactory basketFactory)
        {
            _productRepository = productRepository;
            _basketFactory = basketFactory;
        }

        public IActionResult Index()
        {
            return View(new Order{});
        }

        public IActionResult Calculate(Order order)
        {
            var basket = _basketFactory.CreateBasket();
            basket.AddProduct(_productRepository.GetByName("Milk"), order.Milk);
            basket.AddProduct(_productRepository.GetByName("Butter"), order.Butter);
            basket.AddProduct(_productRepository.GetByName("Bread"), order.Bread);
            order.Total = basket.Total;
            return View("index",order);
        }
    }
}
