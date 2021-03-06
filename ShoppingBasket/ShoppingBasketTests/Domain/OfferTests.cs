﻿using System;
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
        public void WhenNoPurchase_ShouldReturn0()
        {
            var sut = new Offer
            {
                MinimalPurchases = new List<OfferLine>
                {
                    new OfferLine {Product = ProductRepositoryMock.Butter, Quantity = 2},
                    new OfferLine {Product = ProductRepositoryMock.Bread, Quantity = 1}
                },
                Discount = ProductRepositoryMock.Bread.Price * 0.5m
            };

            Assert.Equal(0m, sut.CalculateDiscount(Enumerable.Empty<BasketLine>()));

        }

        [Fact]
        public void WhenMinimalPurchaseDone_ShouldReturnCorrectDiscount()
        {
            var sut = new Offer
            {
                MinimalPurchases = new List<OfferLine>
                {
                    new OfferLine {Product = ProductRepositoryMock.Butter, Quantity = 2},
                    new OfferLine {Product = ProductRepositoryMock.Bread, Quantity = 1}
                },
                Discount = ProductRepositoryMock.Bread.Price * 0.5m
            };

            Assert.Equal(0.5m, sut.CalculateDiscount(new List<BasketLine>
                {
                    new BasketLine
                    {
                        Product = ProductRepositoryMock.Butter, Quantity = 2
                    },
                    new BasketLine
                    {
                        Product = ProductRepositoryMock.Bread, Quantity =  1
                    }
                    
                }));
        }
        [Fact]
        public void WhenMinimalPurchaseNotDone_ShouldReturn0()
        {
            var sut = new Offer
            {
                MinimalPurchases = new List<OfferLine>
                {
                    new OfferLine {Product = ProductRepositoryMock.Butter, Quantity = 2},
                    new OfferLine {Product = ProductRepositoryMock.Bread, Quantity = 1}
                },
                Discount = ProductRepositoryMock.Bread.Price * 0.5m
            };

            Assert.Equal(0m, sut.CalculateDiscount(new List<BasketLine>
            {
                new BasketLine
                {
                    Product = ProductRepositoryMock.Butter, Quantity = 1
                },
                new BasketLine
                {
                    Product = ProductRepositoryMock.Bread, Quantity =  1
                }

            }));
        }

        [Fact]
        public void WhenMinimalPurchaseMetMultipeTimes_ShouldReturnMutlipeDiscount()
        {
            var sut = new Offer
            {
                MinimalPurchases = new List<OfferLine>
                {
                    new OfferLine {Product = ProductRepositoryMock.Butter, Quantity = 2},
                    new OfferLine {Product = ProductRepositoryMock.Bread, Quantity = 1}
                },
                Discount = ProductRepositoryMock.Bread.Price * 0.5m
            };

            Assert.Equal(1m, sut.CalculateDiscount(new List<BasketLine>
            {
                new BasketLine
                {
                    Product = ProductRepositoryMock.Butter, Quantity = 4
                },
                new BasketLine
                {
                    Product = ProductRepositoryMock.Bread, Quantity =  2
                }
            }));
        }
    }
}
