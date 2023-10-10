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

         //   Dictionary<string, string> dossiers = new Dictionary<string, string>();
            List<string> fullNameList = new List<string>();
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
                        AddDossier(fullNameList, postsList);
                        break;

                    case WriteAllDossiersMenu:
                        WriteAllDossiers(fullNameList, postsList);
                        break;

                    case RemoveDossierMenu:
                        DeleteDossier(fullNameList, postsList);
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

        private static void AddDossier(List<string> fullNameList, List<string> postsList)
        {
            Console.Write("Введите ФИО: ");
            string fullName = Console.ReadLine();
            Console.Write("\n\nВведите должность: ");
            string post = Console.ReadLine();

            fullNameList.Add(fullName);
            postsList.Add(post);
        }

        private static void WriteAllDossiers(List<string> fullNameList, List<string> postsList)
        {
            if (IsArrayEmpty(fullNameList))
                return;

            int correctIndexValue = 1;
            int indexList;

            foreach (string fullName in fullNameList)
            {
                indexList = fullNameList.IndexOf(fullName);
                Console.WriteLine($"{indexList + correctIndexValue}) {fullName} - {postsList[indexList]}");
            }
        }

        private static void DeleteDossier(List<string> fullNameList, List<string> postsList)
        {
            if (IsArrayEmpty(fullNameList))
                return;

            int correctIndexValue = 1;
            int indexList;

            WriteAllDossiers(fullNameList, postsList);

            Console.Write("\nКого удалить из списка (введите порядковый номер): ");
            int personeListDeleted = Convert.ToInt32(Console.ReadLine());

            if (fullNameList.Count >= personeListDeleted && personeListDeleted > 0)
            {
                indexList = personeListDeleted - correctIndexValue;
                fullNameList.RemoveAt(indexList);
                postsList.RemoveAt(indexList);
            }
            else
            {
                Console.WriteLine("Некорректный ввод или данное ФИО отсутствует");
                return;
            }
        }

        private static bool IsArrayEmpty(List<string> fullNameList)
        {
            if (fullNameList.Count == 0)
            {
                Console.WriteLine("Список пуст!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}