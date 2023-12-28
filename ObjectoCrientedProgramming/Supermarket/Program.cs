using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Supermarket
    {

    }

    class Customer
    {
        private List<Product> _products;
        public Customer()
        {
        }

        public float Money { get; private set; }

        public void Buy(float money, List<Product> products)
        {
            _products = products;
            Console.WriteLine("Cпасибо за продукты!");
        }

        //private void DeleteRandomProduct()
        //{
        //    int firstProductList = 0;
        //    int indexProduct = _random.Next(firstProductList, _products.Count);

        //    _products.Remove(_products[indexProduct]);
        //}
    }

    class BoxOffice
    {
        private Random _random;
        private List<Product> _products;

        public BoxOffice()
        {
            _random = new Random();
        }

        public float Money { get; private set; }
        public float CheckAmount { get; private set; }

        public List<Product> TrySellProducts(float moneyCustomer)
        {
            while(CheckAmount > moneyCustomer && CheckAmount > 0)
                DeleteRandomProduct();

            if (CheckAmount > 0)
                Money = CheckAmount;
            
            return _products;
        }

        private void DeleteRandomProduct()
        {
            int firstProductList = 0;
            int indexProduct = _random.Next(firstProductList, _products.Count);

            _products.Remove(_products[indexProduct]);
            CheckAmount = SumProducts();
        }

        public float SumProducts()
        {
            float sum = 0;

            foreach(Product product in _products)
            {
                sum += product.Coast;
            }

            return sum;
        }
    }

    class Product
    {
        public Product(string name, float coast)
        {
            Name = name;
            Coast = coast;
        }

        public float Coast { get; private set; }
        public string Name { get; private set; }
    }
}
