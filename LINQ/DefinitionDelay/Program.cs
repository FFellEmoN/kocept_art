using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.Work();
        }
    }

    class Warehouse
    {
        private List<Stew> _stews = new List<Stew>();

        public Warehouse()
        {
            _stews.Add(new Stew("Моя цена", 2005, 20));
            _stews.Add(new Stew("Лента", 2014, 8));
            _stews.Add(new Stew("365 дней", 1990, 1));
            _stews.Add(new Stew("Каждый день", 2020, 1));
            _stews.Add(new Stew("Красная цена", 2019, 5));
            _stews.Add(new Stew("ГОСТ", 2017, 8));
            _stews.Add(new Stew("Барко", 2025, 6));
            _stews.Add(new Stew("ГродФуд", 2010, 6));
            _stews.Add(new Stew("ВкусВилл", 2024, 10));
            _stews.Add(new Stew("Честный продукт", 2021, 4));
            _stews.Add(new Stew("ГлавПродукт", 2022, 6));
            _stews.Add(new Stew("Наша семья", 2020, 5));
        }

        public void Work()
        {
            const string ShowStewsMenu = "1";
            const string ShowExpiredStewsMenu = "2";
            const string ExitMenu = "3";

            bool isWork = true;
            string diciredAction;

            while (isWork == true)
            {
                Console.WriteLine($"{ShowStewsMenu}) - вывести всю тушёнку.");
                Console.WriteLine($"{ShowExpiredStewsMenu}) - вывести просроченную тушёнку.");
                Console.WriteLine($"{ExitMenu}) - выход.");

                Console.Write("\nВыбирите желаемое действие: ");
                diciredAction = Console.ReadLine();

                switch (diciredAction)
                {
                    case ShowStewsMenu:
                        ShowStews(_stews);
                        break;

                    case ShowExpiredStewsMenu:
                        ShowExpiredStews();
                        break;

                    case ExitMenu:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Не верный ввод, попробуйте еще раз.");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ShowStews(List<Stew> stews)
        {
            Console.WriteLine("\nТушёнка:");

            foreach (var stew in stews)
            {
                stew.ShowDetails();
            }
        }

        private void ShowExpiredStews()
        {
            int todaysYear = 2022;

            var expiredStews = _stews.Where(_stews => (_stews.YearOfProduction + _stews.ExpirationDate) < todaysYear).ToList();

            Console.WriteLine($"Просроченная тушёнка, по сегодняшнему {todaysYear} году:");

            ShowStews(expiredStews);
        }
    }

    class Stew
    {
        public string Name { get; private set; }
        public int YearOfProduction { get; private set; }
        public int ExpirationDate { get; private set; }

        public Stew(string initials, int yearOfProduction, int expirationDate)
        {
            Name = initials;
            YearOfProduction = yearOfProduction;
            ExpirationDate = expirationDate;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Тушёнка - {Name}, год поизводства - {YearOfProduction}, срок годности - {ExpirationDate}.");
        }
    }
}