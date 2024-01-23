using System;
using System.Collections.Generic;

namespace Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.StartExcursion();
            Console.ReadLine();
        }
    }

    struct AnimalInfo
    {
        public AnimalInfo(string name, string voice)
        {
            Name = name;
            Voice = voice;
        }

        public string Name { get; private set; }
        public string Voice { get; private set; }
    }

    class Zoo
    {
        private List<Aviary> _aviaries;
        private List<AnimalInfo> _typesAnimals;

        public Zoo()
        {
            _aviaries = new List<Aviary>();
            _typesAnimals = new List<AnimalInfo>
            {
                new AnimalInfo("Тигр", "Р-р-р"),
                new AnimalInfo("Овца", "Беее"),
                new AnimalInfo("Жираф", "Хрум-хрум"),
                new AnimalInfo("Бегемот", "Фырк-фырк"),
                new AnimalInfo("Крокодил", "Клоц-клоц")
            };

            CreateAviary();
        }

        public void StartExcursion()
        {
            string exitMenu = $"{_aviaries.Count + 1}";

            bool isWork = true;

            Console.WriteLine($"Добро пожаловать в зоопарк. У нас есть {_aviaries.Count} вальеров с животными.");

            while (isWork)
            {
                ShowAviaries();
                Console.WriteLine();

                for (int i = 0; i < _aviaries.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - выбрать {_aviaries[i].TypeAnimal.Name} вольер.");
                }

                Console.WriteLine($"{exitMenu} - выйти.");

                Console.Write("Введите желаемое действие: ");
                string diciredAviary = Console.ReadLine();

                if (diciredAviary != exitMenu)
                {
                    ShowAviary(diciredAviary);
                }
                else
                {
                    isWork = false;
                }

                Console.WriteLine("Для того, чтобы продолжить, нажмите любую клавишу.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateAviary()
        {
            foreach (AnimalInfo typeAnimal in _typesAnimals)
            {
                _aviaries.Add(new Aviary(typeAnimal));
            }
        }

        private void ShowAviaries()
        {
            for (int i = 0; i < _aviaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}) Животное: {_aviaries[i].TypeAnimal.Name}, " +
                    $"Количество: {_aviaries[i].ValueAnimals}");
            }
        }

        private void ShowAviary(string inputNumberAviary)
        {
            int numberAviary = int.Parse(inputNumberAviary);

            Aviary aviary = _aviaries[numberAviary - 1];
            Console.WriteLine($"Тип животного: {aviary.TypeAnimal.Name}");
            aviary.ShowAnimals();
        }
    }

    class Aviary
    {
        private List<Animal> _animals;

        public Aviary(AnimalInfo typeAnimal)
        {
            _animals = new List<Animal>();
            ValueAnimals = 5;
            TypeAnimal = typeAnimal;

            Fill();
        }

        public AnimalInfo TypeAnimal { get; private set; }
        public int ValueAnimals { get; private set; }

        public void ShowAnimals()
        {
            Console.WriteLine($"\nКоличиство животных в вольере - {_animals.Count}");

            foreach (var animal in _animals)
            {
                Console.WriteLine($"{animal.Name}. Пол - {animal.Gender}. Звук голоса - {animal.Voice}");
            }
        }

        private void Fill()
        {
            for (int i = 0; i < ValueAnimals; i++)
            {
                _animals.Add(new Animal(TypeAnimal));
            }
        }
    }

    class Animal
    {
        private static Random s_random = new Random();
        private string[] _gender = new string[] { "Мужской", "Женский" };

        public Animal(AnimalInfo typeAnimal)
        {
            Name = typeAnimal.Name;
            Gender = GetGenderAnimal();
            Voice = typeAnimal.Voice;
        }

        public string Name { get; private set; }
        public string Voice { get; private set; }
        public string Gender { get; private set; }

        private string GetGenderAnimal()
        {
            int indexGender = s_random.Next(0, _gender.Length);

            return _gender[indexGender];
        }
    }
}