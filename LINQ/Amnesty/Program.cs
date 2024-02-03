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
            Crime = CreateCrime();
        }

        public string FullName { get; }
        public string Crime { get; }

        public void ShowInformation()
        {
            Console.WriteLine($"Имя: {FullName} | Правонарушение: {Crime}");
        }

        private string CreateCrime()
        {
            string[] nameOfCrimes = { "Антиправительственное", "Административное", "Уголовное" };

            int randomIndex = s_random.Next(nameOfCrimes.Length);

            return nameOfCrimes[randomIndex];
        }
    }

    class Prison
    {
        private List<Criminal> _criminals;

        public Prison()
        {
            _criminals = new List<Criminal>
            {
                new Criminal("Винокуров Даниил Степанович"),
                new Criminal("Орлов Даниил Михайлович"),
                new Criminal("Пупенчик Андрей Владимирович"),
                new Criminal("Рыжова Марина Макаровна"),
                new Criminal("Гусев Мирон Никитич"),
                new Criminal("Смирнов Роман Александрович"),
                new Criminal("Ершов Михаил Иванович"),
                new Criminal("Некрасов Степан Иванович"),
                new Criminal("Косарева Виктория Захаровна"),
                new Criminal("Колесникова Екатерина Марковна")
            };
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