using System.Collections.Generic;

namespace UnitTesting
{
    public class Store : IStore
    {

        private Dictionary<Product, int> _product = new Dictionary<Product, int>();

        public void AddProduct(Product product, int count)
        {
            if (_product.ContainsKey(product))
            {
                _product[product] += count;
            }
            else
            {
                _product[product] = count;
            }
        }
        public void RemoveProduct(Product product, int count)
        {
            if (HasEnough(product, count))
            {
                _product[product] -= count;
            }
        }

        public bool HasEnough(Product product, int count)
        {
            return _product.ContainsKey(product) && _product[product] >= count;
        }
        public int Inventory(Product product)
        {
            if (_product.ContainsKey(product))
            {
                return _product[product];
            }
            return 0;
        }
    }
}
