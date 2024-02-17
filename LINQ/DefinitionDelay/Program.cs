using System;
using System.Collections.Generic;
using System.Linq;

namespace DrfinitionDelay
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
        private List<Stew> _stews;

        public Warehouse()
        {
            _stews = new List<Stew>
            {
                new Stew("Моя цена", 2005, 20),
                new Stew("Лента", 2014, 8),
                new Stew("365 дней", 1990, 1),
                new Stew("Каждый день", 2020, 1),
                new Stew("Красная цена", 2019, 5),
                new Stew("ГОСТ", 2017, 8),
                new Stew("Барко", 2025, 6),
                new Stew("ГродФуд", 2010, 6),
                new Stew("ВкусВилл", 2024, 10),
                new Stew("Честный продукт", 2021, 4),
                new Stew("ГлавПродукт", 2022, 6),
                new Stew("Наша семья", 2020, 5)
            };
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
                        ShowStews();
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

        private void ShowStews()
        {
            Console.WriteLine("\nТушёнка:");

            foreach (var stew in _stews)
            {
                stew.ShowIhfo();
            }
        }

        private void ShowStews(List<Stew> stews)
        {
            Console.WriteLine("\nТушёнка:");

            foreach (var stew in stews)
            {
                stew.ShowIhfo();
            }
        }

        private void ShowExpiredStews()
        {
            var todaysYear = DateTime.Now.Year;

            var expiredStews = _stews.Where(stew => (stew.YearOfProduction + stew.ExpirationDate) < todaysYear).ToList();

            Console.WriteLine($"Просроченная тушёнка, на нынешний {todaysYear} год:");

            ShowStews(expiredStews);
        }
    }

    class Stew
    {
        public Stew(string name, int yearOfProduction, int expirationDate)
        {
            Name = name;
            YearOfProduction = yearOfProduction;
            ExpirationDate = expirationDate;
        }

        public string Name { get; }
        public int YearOfProduction { get; }
        public int ExpirationDate { get; }

        public void ShowIhfo()
        {
            Console.WriteLine($"Тушёнка - {Name}, год поизводства - {YearOfProduction}, срок годности - {ExpirationDate}.");
        }
    }
}