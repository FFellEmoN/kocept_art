using System;
using System.Collections.Generic;
using System.Linq;

namespace Amnesty
{
    class Program
    {
        static void Main(string[] args)
        {

            Prison jail = new Prison();

            jail.Work();
        }
    }

    class Criminal
    {
        private static Random s_random = new Random();

        public Criminal(string fullName)
        {
            FullName = fullName;
            CreateCrime();
        }

        public string FullName { get; private set; }
        public string Crime { get; private set; }

        public void ShowInformation()
        {
            Console.WriteLine($"Имя: {FullName} | Правонарушение: {Crime}");
        }

        private void CreateCrime()
        {
            string[] nameOfCrimes = { "Антиправительственное", "Административное", "Уголовное" };

            int randomIndex = s_random.Next(nameOfCrimes.Length);

            Crime = nameOfCrimes[randomIndex];
        }
    }

    class Prison
    {
        private List<Criminal> _criminals = new List<Criminal>();

        public Prison()
        {
            _criminals.Add(new Criminal("Винокуров Даниил Степанович"));
            _criminals.Add(new Criminal("Орлов Даниил Михайлович"));
            _criminals.Add(new Criminal("Пупенчик Андрей Владимирович"));
            _criminals.Add(new Criminal("Рыжова Марина Макаровна"));
            _criminals.Add(new Criminal("Гусев Мирон Никитич"));
            _criminals.Add(new Criminal("Смирнов Роман Александрович"));
            _criminals.Add(new Criminal("Ершов Михаил Иванович"));
            _criminals.Add(new Criminal("Некрасов Степан Иванович"));
            _criminals.Add(new Criminal("Косарева Виктория Захаровна"));
            _criminals.Add(new Criminal("Колесникова Екатерина Марковна"));
        }

        public void Work()
        {
            string pardonableCrime = "Антиправительственное";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Список заключенных до амнистии:\n");
            Console.ForegroundColor = ConsoleColor.White;
            ShowCriminals();

            Amnesty(pardonableCrime);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nСписок заключенных после амнистии:\n");
            Console.ForegroundColor = ConsoleColor.White;
            ShowCriminals();
        }

        private void ShowCriminals()
        {
            foreach (Criminal criminal in _criminals)
            {
                criminal.ShowInformation();
            }
        }

        private void Amnesty(string pardonableCrime)
        {
            _criminals = _criminals.Where(criminal => criminal.Crime != pardonableCrime).ToList();
        }
    }
}