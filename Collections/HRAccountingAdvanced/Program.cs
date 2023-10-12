using System;
using System.Collections.Generic;

namespace HRAccountingAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddDossierMenu = "1";
            const string WriteAllDossiersMenu = "2";
            const string RemoveDossierMenu = "3";
            const string ExitMenu = "4";

            List<string> fullNames = new List<string>();
            List<string> postsList = new List<string>();

            string disiredOperation;

            bool doExit = true;

            do
            {
                Console.WriteLine("Выбирите желаемое действие\n\n");
                Console.WriteLine($"{AddDossierMenu} - добавить досье");
                Console.WriteLine($"{WriteAllDossiersMenu} - вывести все досье");
                Console.WriteLine($"{RemoveDossierMenu} - удалить досье");
                Console.WriteLine($"{ExitMenu} - выход");

                Console.Write("\nВведите желаемую операцию: ");
                disiredOperation = Console.ReadLine();

                switch (disiredOperation)
                {
                    case AddDossierMenu:
                        AddDossier(fullNames, postsList);
                        break;

                    case WriteAllDossiersMenu:
                        WriteAllDossiers(fullNames, postsList);
                        break;

                    case RemoveDossierMenu:
                        DeleteDossier(fullNames, postsList);
                        break;

                    case ExitMenu:
                        Console.WriteLine("Досвидания!");
                        doExit = false;
                        break;

                    default:
                        Console.WriteLine("\nТакой операции не существует\n");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            } while (doExit);
        }

        private static void AddDossier(List<string> fullNames, List<string> postsList)
        {
            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();
            Console.Write("\n\nВведите должность: ");
            string post = Console.ReadLine();

            fullNames.Add(name);
            postsList.Add(post);
        }

        private static void WriteAllDossiers(List<string> fullNames, List<string> postsList)
        {
            if (IsArrayEmpty(fullNames.Count))
                return;

            int indexList;

            foreach (string name in fullNames)
            {
                indexList = name.IndexOf(name);
                Console.WriteLine($"{indexList + 1}) {name} - {postsList[indexList]}");
            }
        }

        private static void DeleteDossier(List<string> fullNames, List<string> postsList)
        {
            if (IsArrayEmpty(fullNames.Count))
                return;

            int indexList;

            WriteAllDossiers(fullNames, postsList);

            Console.Write("\nКого удалить из списка (введите порядковый номер): ");
            string inputValue = Console.ReadLine();

            if (int.TryParse(inputValue, out int personeListDeleted) && 
                fullNames.Count >= personeListDeleted && personeListDeleted > 0)
            {
                indexList = personeListDeleted - 1;
                fullNames.RemoveAt(indexList);
                postsList.RemoveAt(indexList);
            }
            else
            {
                Console.WriteLine("Некорректный ввод или данное ФИО отсутствует");
                return;
            }
        }

        private static bool IsArrayEmpty(int lengthList)
        {
            return lengthList > 0;
        }
    }
}