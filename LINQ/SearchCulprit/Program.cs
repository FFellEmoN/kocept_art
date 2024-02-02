using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchCulprit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            SearcherCulprit searchCulpritManager = new SearcherCulprit();
            searchCulpritManager.ShowCriminalsOnRunRequest();
        }
    }

    class SearcherCulprit
    {
        private List<Culprit> _culprits;

        public SearcherCulprit()
        {
            _culprits = new List<Culprit>
            {
                new Culprit("Иванов Иван Иванович", 180, 70, "русский", true),
                new Culprit("Беглецов Юрий Денисович", 160, 50, "русский", false),
                new Culprit("Исключенитус Максим Юрьевич", 160, 50, "русский", true),
                new Culprit("Самаст Игорь Михайлович", 178, 68, "русский", true),
                new Culprit("Катаускас Михаил Денисович", 175, 70, "германец", false),
                new Culprit("Тарасевич Анатолий Иванович", 187, 70, "беларус", true),
            };
        }

        public void ShowCriminalsOnRunRequest()
        {
            string nationality;

            bool isWork = false;

            do
            {
                Console.WriteLine("Введите параметры преступника согласно запросам.");

                Console.Write("\nВведите рост: ");

                if (int.TryParse(Console.ReadLine(), out int inputHeigh))
                {
                    Console.Write("Введите вес: ");
                }
                else
                {
                    isWork = InputError();
                    Console.WriteLine();
                    continue;
                }

                if (int.TryParse(Console.ReadLine(), out int weight))
                {
                    Console.Write("Введите национальность: ");
                    nationality = Console.ReadLine();
                }
                else
                {
                    isWork = InputError();
                    Console.WriteLine();
                    continue;
                }

                if (nationality.Any(char.IsLetter) == false)
                {
                    isWork = InputError();
                    Console.WriteLine();
                    continue;
                }

                var filtredCulpritByCustody = _culprits.Where(culprit =>
                culprit.Heigh == inputHeigh &&
                culprit.IsCustody == false &&
                culprit.Weight == weight &&
                culprit.Nationality.ToLower() == nationality.ToLower()).Select(culprit => culprit);

                if (filtredCulpritByCustody.Any())
                {
                    foreach (var culpritName in filtredCulpritByCustody)
                    {
                        Console.WriteLine(culpritName.FullName);
                    }
                }
                else
                {
                    Console.WriteLine("По вашему запросу ни какого не найдено.");
                }

                isWork = false;
                Console.WriteLine("Введите любую клавишу, чтобы продолжить.");
                Console.ReadKey();
            } while (isWork);
        }

        private bool InputError()
        {
            Console.WriteLine("Вы ввели неверные данные, попробуйте снова.");
            return true;
        }
    }

    class Culprit
    {
        public Culprit(string fullName, int heigh, int weight, string nationality, bool isCustody)
        {
            FullName = fullName;
            Heigh = heigh;
            Weight = weight;
            Nationality = nationality;
            IsCustody = isCustody;
        }

        public string FullName { get; }
        public int Heigh { get; }
        public int Weight { get; }
        public string Nationality { get; }
        public bool IsCustody { get; }
    }
}
