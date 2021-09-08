using AnimalAdoption.Common.Logic;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using Xunit;

namespace AnimalAdoption.Service.Cart.UnitTests
{
    public class CartTests
    {
        [Fact]
        public void CartManagement_EmptyCartAddAnimal_AnAnimalIsAdded()
        {
            var animalId = 1;
            var quantityAmount = 1;

            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var resultingCart = new CartService(memoryCache, new AnimalService()).SetAnimalQuantity("TEST_CART", animalId, quantityAmount);

            Assert.Equal("TEST_CART", resultingCart.Id);
            Assert.Equal(1, resultingCart.CartContents.First(x=>x.Id == animalId).Quantity);
        }

        [Fact]
        public void CartManagement_EmptyCartAddNegativeAnimal_AnAnimalDoesNotGoIntoNegative()
        {
            var animalId = 1;
            var quantityAmount = -1;

            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var resultingCart = new CartService(memoryCache, new AnimalService()).SetAnimalQuantity("TEST_CART", animalId, quantityAmount);

            Assert.Equal("TEST_CART", resultingCart.Id);
            Assert.Equal(0, resultingCart.CartContents.First(x => x.Id == animalId).Quantity);
        }

        [Fact]
        public void CartManagement_EmptyCartAddAnimal_AnimalCount()
        {
            var animalId = 1;
            var quantityAmount = 5;

            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var resultingCart = new CartService(memoryCache, new AnimalService()).SetAnimalQuantity("TEST_CART", animalId, quantityAmount);

            Assert.Equal("TEST_CART", resultingCart.Id);
            Assert.Equal(quantityAmount, resultingCart.CartContents.First(x => x.Id == animalId).Quantity);
        }

        [Fact]
        public void CartManagement_EmptyCartAddMultiAnimal_AnimalCount()
        {
            var animal1Id = 1;
            var animal1QuantityAmount = 5;

            var animal2Id = 2;
            var animal2QuantityAmount = 10;

            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var cartService = new CartService(memoryCache, new AnimalService());

            cartService.SetAnimalQuantity("TEST_CART", animal1Id, animal1QuantityAmount);
            cartService.SetAnimalQuantity("TEST_CART", animal2Id, animal2QuantityAmount);

            var resultingCart = cartService.ListAnimals("TEST_CART");


            Assert.Equal("TEST_CART", resultingCart.Id);
            Assert.Equal(animal1QuantityAmount, resultingCart.CartContents.First(x => x.Id == animal1Id).Quantity);
            Assert.Equal(animal2QuantityAmount, resultingCart.CartContents.First(x => x.Id == animal2Id).Quantity);
        }
    }

}
