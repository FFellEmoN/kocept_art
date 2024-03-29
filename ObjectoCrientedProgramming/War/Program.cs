﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            War war = new War();
            war.Start();
            Console.ReadLine();
        }
    }

    class War
    {
        private List<Country> _countries;
        private Battle _battle;
        private int _valueCountry = 2;

        public War()
        {
            _countries = new List<Country>();
            CreateCountry();
        }

        public void Start()
        {
            int windowWidth = 150;
            int windowHeight = 40;

            Console.WindowHeight = windowHeight;
            Console.WindowWidth = windowWidth;

            for (int i = 1; GetLifeCountries() > 1; i++)
            {
                Console.WriteLine($"\nБой {i}\n\n");
                ExecuteBattle();

                if (GetLifeCountries() > 1)
                {
                    Console.WriteLine($"\nПобедитель в {i} бою {_battle.CountryWiner}");
                }
                else
                {
                    Console.WriteLine($"\nПобедитель в войне {_battle.CountryWiner}");
                }
            }
        }

        private int GetLifeCountries()
        {
            int lifeCountries = 0;

            foreach (Country country in _countries)
            {
                foreach (Platoon platoon in country.GetPlatoons())
                {
                    if (platoon.CountWarriors > 0)
                    {
                        lifeCountries++;
                    }
                }
            }

            return lifeCountries;
        }

        private void ExecuteBattle()
        {
            _battle = new Battle(_countries.ToList<Country>());

            _battle.Execute();
        }

        private void CreateCountry()
        {
            for (int i = 0; i < _valueCountry; i++)
            {
                _countries.Add(CountryBuilder.CreateCountry());
            }
        }
    }

    class Battle
    {
        private List<Country> _countries;

        public Battle(List<Country> countries)
        {
            _countries = countries;
        }

        public string CountryWiner { get; private set; }

        public void Execute()
        {
            List<Warrior> allWarriors = GetAllWarriors();
            int maxWarriors = 0;

            foreach (Warrior warrior in GetAllWarriors())
            {
                warrior.Attack(allWarriors);
            }

            foreach (Country country in _countries)
            {
                foreach (Platoon platoon in country.GetPlatoons())
                {
                    platoon.BuryThoseWarriors();
                    Console.WriteLine($"\n{country.Name} - Потери: {platoon.MaxCountWarriors - platoon.CountWarriors} Солдат");
                    platoon.ShowWarriors();

                    if (maxWarriors < platoon.CountWarriors)
                    {
                        maxWarriors = platoon.CountWarriors;
                        CountryWiner = country.Name;
                    }
                }
            }
        }

        private List<Warrior> GetAllWarriors()
        {
            List<Warrior> allWarrior = new List<Warrior>();

            foreach (Country country in _countries)
            {
                foreach (Platoon platoon in country.GetPlatoons())
                {
                    foreach (Warrior warrior in platoon.GetWarriors())
                    {
                        allWarrior.Add(warrior);
                    }
                }
            }

            return allWarrior.ToList<Warrior>();
        }
    }

    class Country
    {
        private List<Platoon> _platoons = new List<Platoon>();

        public string Name { get; }

        public Country(string name)
        {
            Name = name;
        }

        public List<Platoon> GetPlatoons()
        {
            return _platoons.ToList<Platoon>();
        }

        public void CreatePlatoon(int number, int maxCount)
        {
            _platoons.Add(new Platoon(number, maxCount));
        }
    }

    class Platoon
    {
        private List<Warrior> _warriors = new List<Warrior>();

        public int Number { get; private set; }
        public int CountWarriors => _warriors.Count;
        public int MaxCountWarriors { get; private set; }
        public bool IsWiner => _warriors.Count > 0;

        public Platoon(int number, int maxCount)
        {
            Number = number;
            MaxCountWarriors = maxCount;
        }

        public List<Warrior> GetWarriors()
        {
            return _warriors.ToList<Warrior>();
        }

        public void CreateWarriors(string nationality)
        {
            for (int i = 1; i <= MaxCountWarriors; i++)
            {
                _warriors.Add(new Warrior(i, Number, nationality));
            }
        }

        public void ShowWarriors()
        {
            foreach (var warrior in _warriors)
            {
                Console.WriteLine(warrior.ShowInfo());
            }
        }

        public void BuryThoseWarriors()
        {
            _warriors.RemoveAll(warrior => warrior.Health <= 0);
        }
    }

    class Warrior
    {
        public Warrior(int number, int numberPlatoon, string nationality)
        {
            Health = 100;
            Damage = 35;
            Number = number;
            NumberPlatoon = numberPlatoon;
            Nationality = nationality;
        }

        public int Health { get; private set; }
        public int Number { get; private set; }
        public int NumberPlatoon { get; private set; }
        public string Nationality { get; private set; }
        public int Damage { get; private set; }

        public string ShowInfo()
        {
            return $"Национальность: {Nationality}." +
                $" Номер взвода: {NumberPlatoon}." +
                $" Порядковый номер: {Number}." +
                $" Здоровье: {Health})";
        }

        public void Attack(List<Warrior> targets)
        {
            List<Warrior> enemies = new List<Warrior>();

            foreach (Warrior warrior in targets)
            {
                if (Nationality != warrior.Nationality)
                {
                    enemies.Add(warrior);
                }
            };

            Warrior target = enemies[RandomNumber.GetRandomNumber(enemies.Count)];

            if (target != null)
            {
                target.TakeDamage(Damage);
                Console.WriteLine($"{ShowInfo()}) нанес -{Damage} урона\n-> {target.ShowInfo()}");
            }
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }

    class RandomNumber
    {
        private static Random _random = new Random();

        public static int GetRandomNumber(int number)
        {
            return _random.Next(number);
        }
    }

    class CountryBuilder
    {
        public static Country CreateCountry()
        {
            string nameCountry;

            int maxNumberPlatoon = 101;
            int numberPlatoon = RandomNumber.GetRandomNumber(maxNumberPlatoon);
            int maxNumberWariors = 20;

            Console.Write("Введите название страны: ");
            nameCountry = Console.ReadLine();

            Country country = new Country(nameCountry);

            country.CreatePlatoon(numberPlatoon, maxNumberWariors);

            foreach (Platoon platoon in country.GetPlatoons())
            {
                platoon.CreateWarriors(country.Name);

                Console.WriteLine($"\nСоздан взвод страна {country.Name}:\n");
                platoon.ShowWarriors();
            }

            Console.WriteLine("\nСтрана успешно создана.\n");

            return country;
        }
    }
}