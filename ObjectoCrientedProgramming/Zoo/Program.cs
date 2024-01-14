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

    struct TypeAnimal
    {
        public TypeAnimal(string name, string voce)
        {
            Name = name;
            Voce = voce;
        }

        public string Name { get; private set; }
        public string Voce { get; private set; }
    }

    class Zoo
    {
        private List<Aviary> _aviaries;
        private List<TypeAnimal> _typesAnimals;

        public Zoo()
        {
            _aviaries = new List<Aviary>();
            _typesAnimals = new List<TypeAnimal>
            {
                new TypeAnimal("Тигр", "Р-р-р"),
                new TypeAnimal("Овца", "Беее"),
                new TypeAnimal("Жираф", "Хрум-хрум"),
                new TypeAnimal("Бегемот", "Фырк-фырк"),
                new TypeAnimal("Крокодил", "Клоц-клоц")
            };

            CreateAviary();
        }

        public void StartExcursion()
        {
            const string ChooseAviaryMenu = "1";
            const string ExitMenu = "2";

            bool isWork = true;

            Console.WriteLine($"Добро пожаловать в зоопарк. У нас есть {_aviaries.Count} вальеров с животными.");

            while (isWork)
            {
                ShowAviaries();
                Console.WriteLine();
                Console.WriteLine($"{ChooseAviaryMenu} - выбрать вольер.");
                Console.WriteLine($"{ExitMenu} - выйти.");

                Console.Write("Введите желаемое действие: ");
                string diciredAction = Console.ReadLine();

                switch (diciredAction)
                {
                    case ChooseAviaryMenu:
                        ChooseAviary();
                        break;
                    case ExitMenu:
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Такой команды нету.");
                        break;
                }

                Console.WriteLine("Для того, чтобы продолжить, нажмите любую клавишу.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateAviary()
        {
            foreach (TypeAnimal typeAnimal in _typesAnimals)
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

        private void ShowAviary(int diciredAviary)
        {
            Aviary aviary = _aviaries[diciredAviary - 1];
            Console.WriteLine($"Тип животного: {aviary.TypeAnimal.Name}");
            aviary.ShowAnimals();
        }

        private void ChooseAviary()
        {
            Console.Write("Введите номер вольера: ");

            if (int.TryParse(Console.ReadLine(), out int inputNumberAviary))
            {
                if (inputNumberAviary > 0 && inputNumberAviary <= _aviaries.Count)
                {
                    ShowAviary(inputNumberAviary);
                }
                else
                {
                    Console.WriteLine("Вальера с таким номером в зоопарке нету.");
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз.");
            }
        }
    }

    class Aviary
    {
        private List<Animal> _animals;

        public Aviary(TypeAnimal typeAnimal)
        {
            _animals = new List<Animal>();
            ValueAnimals = 5;
            TypeAnimal = typeAnimal;

            Fill();
        }

        public TypeAnimal TypeAnimal { get; private set; }
        public int ValueAnimals { get; private set; }

        public void ShowAnimals()
        {
            Console.WriteLine($"\nКоличиство животных в вольере - {_animals.Count}");

            foreach (var animal in _animals)
            {
                Console.WriteLine($"{animal.Name}. Пол - {animal.Gender}. Звук голоса - {animal.Voce}");
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
        private static Random _random;

        public Animal(TypeAnimal typeAnimal)
        {
            _random = new Random();
            Name = typeAnimal.Name;
            Gender = GetGenderAnimal();
            Voce = typeAnimal.Voce;
        }

        public string Name { get; private set; }
        public string Voce { get; private set; }
        public string Gender { get; private set; }

        private string GetGenderAnimal()
        {
            int minimumNumberGender = 0;
            int maximumNumberGender = 2;
            int gender = _random.Next(minimumNumberGender, maximumNumberGender);

            if (gender == 0)
            {
                return "Мужской";
            }
            else
            {
                return "Женский";
            }
        }
    }
}