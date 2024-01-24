using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SearchCulprit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            SearchCulpritManager searchCulpritManager = new SearchCulpritManager();
            searchCulpritManager.ShowCriminalsOnRunRequest();
        }
    }

    class SearchCulpritManager
    {
        private List<Culprit> _culprits;

        public SearchCulpritManager()
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
            bool isWork = false;

            do
            {
                Console.WriteLine("Введите параметры преступника согласно запросам.");

                Console.Write("\nВведите рост: ");

                if (int.TryParse(Console.ReadLine(), out int inputHeigh))
                {
                    Console.Write("Введите вес: ");

                    if (int.TryParse(Console.ReadLine(), out int weight))
                    {
                        Console.Write("Введите национальность: ");
                        string nationality = Console.ReadLine();


                        var filtredCulpritByHeigh = _culprits.Where(culprit => culprit.Heigh == inputHeigh).
                            Select(culprit => culprit);
                        var filtredCulpritByWeight = filtredCulpritByHeigh.Where(culprit => culprit.Weight == weight).
                            Select(culprit => culprit);
                        var filtredCulpritByNationality = filtredCulpritByWeight.Where(culprit => culprit.Nationality.ToLower() == nationality.ToLower()).
                            Select(culprit => culprit);
                        var filtredCulpritByCustody = filtredCulpritByNationality.Where(culprit => culprit.IsCustody == false).
                            Select(culprit => culprit);

                        if (filtredCulpritByCustody.Any())
                        {
                            foreach (var culpritName in filtredCulpritByHeigh)
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
                    }
                    else
                    {
                        isWork = InputError();
                    }
                }
                else
                {
                    isWork = InputError();
                }
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

        public string FullName { get; private set; }
        public int Heigh { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }
        public bool IsCustody { get; private set; }
    }
}
