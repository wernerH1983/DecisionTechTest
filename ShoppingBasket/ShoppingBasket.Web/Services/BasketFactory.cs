using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingBasket.Domain;

namespace ShoppingBasket.Web.Services
{
    public class BasketFactory
    {
        private readonly OfferRepository _offerRepository;
        

        public BasketFactory(OfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
            
        }

        public Basket CreateBasket()
        {
            var offers = _offerRepository.GetOffers();
            return new Basket(offers);
        }
    }
}
