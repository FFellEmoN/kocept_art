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
            const string FillBusketsCustomersCommand = "1";
            const string ServeCustomerCommand = "2";
            const string ShowAllNameProductsMenu = "3";
            const string ExitMenu = "4";

            string diciredAction;

            bool isRunning = true;

            do
            {
                Console.WriteLine($"{FillBusketsCustomersCommand}) - заполнить корзины клиентов.");
                Console.WriteLine($"{ServeCustomerCommand}) - обслужить клиента.");
                Console.WriteLine($"{ShowAllNameProductsMenu}) - показать весь список продуктов.");
                Console.WriteLine($"{ExitMenu}) - выйти.");

                Console.Write("\nВведите желаемое действие: ");
                diciredAction = Console.ReadLine();
                Console.WriteLine();

                switch (diciredAction)
                {
                    case FillBusketsCustomersCommand:
                        FillBusketsCustomers();
                        break;

                    case ServeCustomerCommand:
                        ServeCustomer();
                        break;

                    case ShowAllNameProductsMenu:
                        ShowAllNameProducts();
                        break;

                    case ExitMenu:
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Такого пункта нет или вы ввели не число.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить.");

                Console.ReadKey();
                Console.Clear();
            } while (isRunning);
        }

        private void ShowAllNameProducts()
        {
            List<string> allNameProducts = _warehouse.GetListNameProducts();

            for (int i = 0; i < allNameProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {allNameProducts[i]}");
            }
        }

        private void FillBusketsCustomers()
        {
            foreach (Customer customer in _customers)
            {
                foreach (string nameProduct in _warehouse.GetListNameProducts())
                {
                    customer.PutBasketProduct(_warehouse.GetProduct(nameProduct));
                    customer.PutBasketProduct(_warehouse.GetProduct(nameProduct));
                }
            }
        }

        public void ServeCustomer()
        {
            List<Product> finalShoppingList;

            for (int i = 0; i < _customers.Count; i++)
            {
                finalShoppingList = _boxOffice.TrySellProducts(_customers[i].Money, _customers[i].GetBusket());

                Console.WriteLine($"\nСумма чека: {_boxOffice.CheckAmount}" );

                _customers[i].Buy(_boxOffice.CheckAmount, finalShoppingList);
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
            List<string> allNameProducts = _products.Select(x => x.Name).Distinct().ToList();

            return new List<string>(allNameProducts);
        }

        private void Fill()
        {
            int numberRacks = 100;

            for (int i = 0; i < numberRacks; i++)
            {
                _products.Add(new Cucumber());
                _products.Add(new Carrot());
                _products.Add(new Oil());
            }
        }
    }

    class Customer
    {
        private List<Product> _busket;
        public Customer()
        {
            _busket = new List<Product>();
            Money = 200;
        }

        public float Money { get; private set; }

        public List<Product> GetBusket()
        {
            return new List<Product>(_busket);
        }

        public void Buy(float coast, List<Product> products)
        {
            _busket = new List<Product>();
            Money -= coast;

            ShowAllPurchasedProducts(products);
            Console.WriteLine("Cпасибо за продукты!");
        }

        public void PutBasketProduct(Product product)
        {
            _busket.Add(product);
        }

        private void ShowAllPurchasedProducts(List<Product> products)
        {
            Console.WriteLine("Вот, что купил покупатель.");

            foreach (Product product in products)
            {
                Console.WriteLine(product.Name);
            }
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
        private List<Product> _products;

        public float Money { get; private set; }
        public float CheckAmount { get; private set; }

        public List<Product> TrySellProducts(float moneyCustomer, List<Product> products)
        {
            _products = products;
            SumProducts();

            while (CheckAmount > moneyCustomer && moneyCustomer > 0 && _products.Count != 0)
                DeleteRandomProduct();

            Money += CheckAmount;

            return _products;
        }

        private void DeleteRandomProduct()
        {
            int firstProductList = 0;
            int indexProduct = RandomNumber.GenerateRandomNumber(firstProductList, _products.Count);

            Product deleteProduct = _products[indexProduct];

            CheckAmount -= deleteProduct.Coast;
            _products.Remove(deleteProduct);
        }

        private void SumProducts()
        {
            foreach (Product product in _products)
            {
                CheckAmount += product.Coast;
            }
        }
    }

    class Product
    {
        public float Coast { get; protected set; }
        public string Name { get; protected set; }
    }

    class Cucumber : Product
    {
        public Cucumber()
        {
            Name = "Огурец";
            Coast = 20;
        }
    }

    class Carrot : Product
    {
        public Carrot()
        {
            Name = "Морковь";
            Coast = 30;
        }
    }

    class Oil : Product
    {
        public Oil()
        {
            Name = "Масло";
            Coast = 200;
        }
    }
}
