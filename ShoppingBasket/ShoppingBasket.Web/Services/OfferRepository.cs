using System.Collections.Generic;
using ShoppingBasket.Domain;

namespace ShoppingBasket.Web.Services
{
    public class OfferRepository
    {
        private readonly ProductRepository _productRepository;

        public OfferRepository(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Offer> GetOffers()
        {
            return new List<Offer>
            {
                new Offer
                {
                    MinimalPurchases = new List<OfferLine>
                    {
                        new OfferLine {Product = _productRepository.GetByName("Butter"), Quantity = 2},
                        new OfferLine {Product = _productRepository.GetByName("Bread"), Quantity = 1}
                    },
                    Discount = _productRepository.GetByName("Bread").Price * 0.5m
                },
                new Offer
                {
                    MinimalPurchases = new List<OfferLine>
                    {
                        new OfferLine {Product = _productRepository.GetByName("Milk"), Quantity = 4},
                    },
                    Discount = _productRepository.GetByName("Milk").Price
                }
            };
        }

    }
}
