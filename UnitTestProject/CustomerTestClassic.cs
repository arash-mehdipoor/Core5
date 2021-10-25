using System;
using UnitTesting;
using Xunit;

namespace UnitTestProject
{
    public class CustomerTestClassic
    {
        [Fact]
        public void Purchase_Done_Correct_Whene_Store_Has_Enough_Inventory()
        {
            Customers customers = new Customers();

            Product product = new Product() { Name = "Arash" };

            var store = new Store();
            store.AddProduct(product, 20);

            var result = customers.Purchase(store, product, 10);

            Assert.True(result);
            Assert.Equal(10, store.Inventory(product));
        }

        [Fact]
        public void Purchase_Done_Whene_Store_Has_Enough_NOT_Inventory()
        {
            Customers customers = new Customers();

            Product product = new Product() { Name = "Arash" };

            var store = new Store();
            store.AddProduct(product, 5);

            var result = customers.Purchase(store, product, 10);

            Assert.False(result);
            Assert.Equal(5, store.Inventory(product));
        }
    }
}
