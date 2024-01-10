using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();
            aquarium.Work();
        }
    }

    class Aquarium
    {
        private List<Fish> _fish = new List<Fish>();
        private int _maximumFishLife = 10;

        public void Work()
        {
            const string addFishMenu = "1";
            const string pickUpFishAquariumMenu = "2";
            const string ExitMenu = "3";

            bool isWork = true;

            string diciredAction;

            do
            {
                RemoveDeedFish();
                GetRestYourLife();
                ShowAquarium();

                Console.WriteLine("Добро пожаловать!!!");
                Console.WriteLine($"{addFishMenu} - добавить рыбу.");
                Console.WriteLine($"{pickUpFishAquariumMenu} - достать рыбу из аквариума.");
                Console.WriteLine($"{ExitMenu} - выйти.");

                Console.Write("Введите команду:");
                diciredAction = Console.ReadLine();

                switch (diciredAction)
                {
                    case "1":
                        AddFish();
                        break;

                    case "2":
                        RemoveFish();
                        break;

                    case "3":
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

        private void AddFish()
        {
            int maximumFish = 10;

            if (_fish.Count < maximumFish)
            {
                string name;
                string userInput;

                Console.Write("Введите название рыбы: ");
                name = Console.ReadLine();

                Console.Write("Введите сколько лет рыбе: ");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int age) == false)
                {
                    Console.WriteLine("Не верный ввод");
                }
                else if (age >= _maximumFishLife)
                {
                    Console.WriteLine("Столько рыбы не живут, наверно вы что-то перепутали.");
                }
                else
                {
                    _fish.Add(new Fish(name, age));

                    Console.WriteLine("Рыба успешно дабавлена");
                }
            }
            else
            {
                Console.WriteLine("Место в аквариуме закончилось");
            }
        }

        private void RemoveFish()
        {
            string userInput;
            int initialQuantity = _fish.Count;

            if (_fish.Count > 0)
            {
                Console.WriteLine("Введите номер рыбы, которую хотите достать из аквариума:");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int number))
                {
                    for (int i = 0; i < _fish.Count; i++)
                    {
                        if (number == i + 1)
                        {
                            Console.WriteLine("Рыбу успешно достали");
                            _fish.Remove(_fish[i]);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Рыб в аквариуме нету");
            }

            if (initialQuantity == _fish.Count)
            {
                Console.WriteLine("Такой рыбы в аквариуме нету");
            }
        }

        private void RemoveDeedFish()
        {
            foreach (Fish fish in _fish)
            {
                if (fish.Age >= _maximumFishLife)
                {
                    Console.WriteLine($"Рыбка {fish.Name} умерла от старости");
                    _fish.Remove(fish);
                }
            }
        }

        private void ShowAquarium()
        {
            Console.WriteLine("Аквариум:");

            if (_fish.Count > 0)
            {
                for (int i = 0; i < _fish.Count; i++)
                {
                    Console.Write((i + 1) + ") ");
                    _fish[i].ShowFish();
                }
            }
            else
            {
                Console.WriteLine("В аквариуме нету рыб");
            }

            Console.SetCursorPosition(0, 15);
        }

        private void GetRestYourLife()
        {
            foreach (Fish fish in _fish)
            {
                fish.LiveToDeath();
            }
        }
    }

    class Fish
    {
        public Fish(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

        public void ShowFish()
        {
            Console.WriteLine($"{Name} - возраст {Age} лет");
        }

        public void LiveToDeath()
        {
            Age++;
        }
    }
}