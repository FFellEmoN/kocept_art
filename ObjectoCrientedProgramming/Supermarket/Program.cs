using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Supermarket supermarket = new Supermarket();
            supermarket.Work();
        }
    }

    class Supermarket
    {
        private BoxOffice _boxOffice;
        private List<Customer> _customers;
        private Warehouse _warehouse;

        public Supermarket()
        {
            _warehouse = new Warehouse();
            _boxOffice = new BoxOffice();
            _customers = new List<Customer>
            {
                new Customer(),
                new Customer(),
                new Customer()
            };
        }

        public void Work()
        {
            ShowAllNameProducts();
            Console.WriteLine();
            FillBusketsCustomers();
            Console.WriteLine("\nОбслуживание клиентов.");
            ServeCustomer();
            Console.WriteLine("\nОбслуживание клиентов завершенно.");
            Console.ReadLine();
        }

        private void ShowAllNameProducts()
        {
            List<string> allNameProducts = _warehouse.GetListNameProducts();

            Console.WriteLine("Все типы продуктов в супермаркете:");

            for (int i = 0; i < allNameProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {allNameProducts[i]}");
            }
        }

        private void FillBusketsCustomers()
        {
            int valueProductsOneTypeInBusket = 1;
            foreach (Customer customer in _customers)
            {
                foreach (string nameProduct in _warehouse.GetListNameProducts())
                {
                    for (int i = 0; i < valueProductsOneTypeInBusket; i++)
                    {
                        customer.PutBasketProduct(_warehouse.GetProduct(nameProduct));
                    }
                }
            }

            Console.WriteLine("Корзины покупателей заполненны.");
        }

        public void ServeCustomer()
        {
            for (int i = 0; i < _customers.Count; i++)
            {
                _boxOffice.TrySellProducts(_customers[i]);

                Console.WriteLine($"Сумма чека: {_customers[i].CheakAmount}\n");
            }
        }
    }

    class Warehouse
    {
        private List<Product> _products;

        public Warehouse()
        {
            _products = new List<Product>();
            Fill();
        }

        public Product GetProduct(string nameDiciredProduct)
        {
            foreach (Product product in _products)
            {
                if (product.Name == nameDiciredProduct)
                {
                    _products.Remove(product);

                    return product;
                }
            }

            Console.WriteLine("Продукта нет на складе.");

            return null;
        }

        public List<string> GetListNameProducts()
        {
            List<string> allNameProducts = _products.Select(product => product.Name).Distinct().ToList();

            return allNameProducts;
        }

        private void Fill()
        {
            int numberRacks = 100;

            for (int i = 0; i < numberRacks; i++)
            {
                _products.Add(new Product("Огурец", 20));
                _products.Add(new Product("Морковь", 30));
                _products.Add(new Product("Масло", 200));
            }
        }
    }

    class Customer
    {
        private List<Product> _basket;
        public Customer()
        {
            _basket = new List<Product>();
            Money = 200;
        }

        public float CheakAmount { get; private set; }
        public float Money { get; private set; }

        public List<Product> GetBusket()
        {
            return new List<Product>(_basket);
        }

        public void TryBuy()
        {
            SumProducts();

            while (CheakAmount > Money && Money > 0 && _basket.Count != 0)
                DeleteRandomProduct();

            ShowAllPurchasedProducts(_basket);

            Money -= CheakAmount;

            Console.WriteLine("Cпасибо за продукты!");
        }

        public void PutBasketProduct(Product product)
        {
            _basket.Add(product);
        }

        private void ShowAllPurchasedProducts(List<Product> products)
        {
            Console.WriteLine("Вот, что купил покупатель.");

            foreach (Product product in products)
            {
                Console.WriteLine(product.Name);
            }
        }

        private void SumProducts()
        {
            foreach (Product product in _basket)
            {
                CheakAmount += product.Coast;
            }
        }

        private void DeleteRandomProduct()
        {
            int firstProductList = 0;
            int indexProduct = RandomNumber.GenerateRandomNumber(firstProductList, _basket.Count);

            Product deleteProduct = _basket[indexProduct];

            CheakAmount -= deleteProduct.Coast;
            _basket.Remove(deleteProduct);
        }
    }

    class RandomNumber
    {
        private static Random s_random = new Random();

        public static int GenerateRandomNumber(int min, int max)
        {
            return s_random.Next(min, max);
        }
    }

    class BoxOffice
    {
        public float Money { get; private set; }

        public void TrySellProducts(Customer customer)
        {
            customer.TryBuy();
            Money += customer.CheakAmount;
            Console.WriteLine("Приходите еще!");
        }
    }

    class Product
    {
        public Product(string name, float coast) 
        { 
            Name = name;
            Coast = coast;
        }

        public string Name { get; protected set; }
        public float Coast { get; protected set; }
    }
}