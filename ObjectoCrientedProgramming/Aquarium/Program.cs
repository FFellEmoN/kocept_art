using System;
using System.Collections.Generic;

namespace Aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            AquariumManager aquariumManager = new AquariumManager();
            aquariumManager.Work();
        }
    }

    class AquariumManager
    {
        private Aquarium _aquarium;

        public AquariumManager()
        {
            _aquarium = new Aquarium();
        }

        public void Work()
        {
            const string AddFishCommand = "1";
            const string PickUpFishCommand = "2";
            const string ExitCommand = "3";

            bool isWork = true;

            string diciredAction;

            do
            {
                _aquarium.RemoveDeedFishes();
                _aquarium.GiveRestYourLife();
                _aquarium.Show();

                Console.WriteLine("Добро пожаловать!!!");
                Console.WriteLine($"{AddFishCommand} - добавить рыбу.");
                Console.WriteLine($"{PickUpFishCommand} - достать рыбу из аквариума.");
                Console.WriteLine($"{ExitCommand} - выйти.");

                Console.Write("Введите команду:");
                diciredAction = Console.ReadLine();

                switch (diciredAction)
                {
                    case AddFishCommand:
                        _aquarium.AddFish();
                        break;

                    case PickUpFishCommand:
                        _aquarium.RemoveFish();
                        break;

                    case ExitCommand:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Не верный ввод");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            } while (isWork);
        }
    }

    class FishFactory
    {
        public static Fish CreateFish()
        {
            int maximumFishLife = 10;

            Console.Write("Введите название рыбы: ");
            string name = Console.ReadLine();

            Console.Write("Введите сколько лет рыбе: ");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int age) == false)
            {
                Console.WriteLine("Не верный ввод");

                return null;
            }
            else if (age >= maximumFishLife)
            {
                Console.WriteLine("Столько рыбы не живут, наверно вы что-то перепутали.");

                return null;
            }
            else
            {
                Console.WriteLine("Рыба успешно дабавлена");

                return new Fish(name, age);
            }
        }
    }

    class Aquarium
    {
        private List<Fish> _fishes = new List<Fish>();

        public void AddFish()
        {
            int maximumFish = 10;

            if (_fishes.Count >= maximumFish)
            {
                Console.WriteLine("Место в аквариуме закончилось");

                return;
            }

            _fishes.Add(FishFactory.CreateFish());
        }

        public void RemoveFish()
        {
            int initialQuantity = _fishes.Count;

            if (_fishes.Count > 0)
            {
                Console.WriteLine("Введите номер рыбы, которую хотите достать из аквариума:");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int number) && number <= _fishes.Count && number > 0)
                {
                    Console.WriteLine("Рыбу успешно достали");
                    _fishes.Remove(_fishes[number - 1]);
                }

                if (initialQuantity == _fishes.Count)
                {
                    Console.WriteLine("Такой рыбы в аквариуме нету");
                }
            }
            else
            {
                Console.WriteLine("Рыб в аквариуме нету");
            }
        }

        public void RemoveDeedFishes()
        {
            int lastIndex = _fishes.Count - 1;

            for (int i = lastIndex; i >= 0; i--)
            {
                if (_fishes[i].Age == _fishes[i].MaximumFishLife)
                {
                    Console.WriteLine($"Рыбка {_fishes[i].Name} умерла от старости");

                    _fishes.Remove(_fishes[i]);
                }
            }
        }

        public void Show()
        {
            Console.WriteLine("Аквариум:");

            if (_fishes.Count > 0)
            {
                for (int i = 0; i < _fishes.Count; i++)
                {
                    Console.Write((i + 1) + ") ");
                    _fishes[i].Show();
                }
            }
            else
            {
                Console.WriteLine("В аквариуме нету рыб");
            }

            Console.SetCursorPosition(0, 15);
        }

        public void GiveRestYourLife()
        {
            foreach (Fish fish in _fishes)
            {
                fish.GrowOld();
            }
        }
    }

    class Fish
    {
        public Fish(string name, int age)
        {
            Name = name;
            Age = age;
            MaximumFishLife = 10;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public int MaximumFishLife { get; private set; }

        public void Show()
        {
            Console.WriteLine($"{Name} - возраст {Age} лет");
        }

        public void GrowOld()
        {
            Age++;
        }
    }
}