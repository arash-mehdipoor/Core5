using System.Collections.Generic;

namespace UnitTesting
{
    public class Customers
    {
        private Dictionary<Product, int> _basket = new Dictionary<Product, int>();


        public bool Purchase(IStore store, Product product, int count)
        {
            if (store.HasEnough(product, count))
            {
                store.RemoveProduct(product, count);
                _basket[product] = count;
                return true;
            }
            return false;
        }
    }
}
