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

            Dictionary<string, string> dossiers = new Dictionary<string, string>();

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
                        AddDossier(dossiers);
                        break;

                    case WriteAllDossiersMenu:
                        WriteAllDossiers(dossiers);
                        break;

                    case RemoveDossierMenu:
                        DeleteDossier(dossiers);
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

        private static void AddDossier(Dictionary<string, string> dossiers)
        {
            Console.Write("Введите ФИО: ");
            string fullName = Console.ReadLine();
            Console.Write("\n\nВведите должность: ");
            string post = Console.ReadLine();

            dossiers.Add(fullName, post);
        }

        private static void WriteAllDossiers(Dictionary<string, string> dossiers)
        {
            if (IsArrayEmpty(dossiers))
                return;

            int personOnDictionary = 1;

            foreach (KeyValuePair<string, string> item in dossiers)
            {
                Console.WriteLine($"{personOnDictionary}) {item.Key} - {item.Value}");

                personOnDictionary++;
            }
        }

        private static void DeleteDossier(Dictionary<string, string> dossiers)
        {
            if (IsArrayEmpty(dossiers))
                return;

            string keyOnListDeleted;

            WriteAllDossiers(dossiers);

            Console.Write("\nКого удалить из списка (введите ФИО): ");
            keyOnListDeleted = Console.ReadLine();

            if (dossiers.ContainsKey(keyOnListDeleted))
            {
                dossiers.Remove(keyOnListDeleted);
            }
            else
            {
                Console.WriteLine("Некорректный ввод или данное ФИО отсутствует");
                return;
            }
        }

        private static bool IsArrayEmpty(Dictionary<string, string> dossiers)
        {
            if (dossiers.Count == 0)
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