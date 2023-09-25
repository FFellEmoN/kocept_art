using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PersonnelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int AddDossierMenu = 1;
            const int WriteAllDossiersMenu = 2;
            const int RemoveDossierMenu = 3;
            const int SearchBySurnameMenu = 4;
            const int ExitMenu = 5;

            string[] listPersonnels = new string[0];
            string[] listPosts = new string[0];

            int disiredOperation;

            do
            {
                Console.WriteLine("Выбирите желаемое действие\n\n");
                Console.WriteLine($"{AddDossierMenu} - добавить досье");
                Console.WriteLine($"{WriteAllDossiersMenu} - вывести все досье");
                Console.WriteLine($"{RemoveDossierMenu} - удалить досье");
                Console.WriteLine($"{SearchBySurnameMenu} - поиск по фамилии");
                Console.WriteLine($"{ExitMenu} - выход");

                Console.Write("\nВведите желаемую операцию: ");
                disiredOperation = Convert.ToInt32(Console.ReadLine());

                switch (disiredOperation)
                {
                    case AddDossierMenu:
                        AddDossier(ref listPersonnels, ref listPosts);
                        break;

                    case WriteAllDossiersMenu:
                        WriteAllDossiers(listPersonnels, listPosts);
                        break;

                    case RemoveDossierMenu:
                        DeletePersonnelInDossier(ref listPersonnels, ref listPosts);
                        break;

                    case SearchBySurnameMenu:
                        SearchSurname(listPersonnels, listPosts);
                        break;

                    case ExitMenu:
                        Console.WriteLine("Досвидания!");
                        break;

                    default:
                        Console.WriteLine("\nТакой операции не существует\n");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            } while (disiredOperation != ExitMenu);
        }

        private static void AddDossier(ref string[] listPersonnels, ref string[] listPosts)
        {
            int valueIncreasingArray = 1;

            listPersonnels = IncreaseStringArray(listPersonnels, valueIncreasingArray);
            listPosts = IncreaseStringArray(listPosts, valueIncreasingArray);
            int lastIndexArray = listPosts.Length - 1;

            Console.Write("Введите фамилию: ");
            string surname = Console.ReadLine();
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите отчество: ");
            string patronymic = Console.ReadLine();
            Console.Write("Введите должность: ");
            string post = Console.ReadLine();

            string fullName = surname + " " + name + " " + patronymic;
            listPersonnels[lastIndexArray] = fullName;
            listPosts[lastIndexArray] = post;
        }

        private static string[] IncreaseStringArray(string[] array, int value)
        {
            int lengthArray = array.Length + value;

            string[] newArray = new string[lengthArray];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        private static string[] ReduceStringArray(string[] array, int value)
        {
            int lengthArray = array.Length + value;

            string[] newArray = new string[lengthArray];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        private static void WriteAllDossiers(string[] listPersonnels, string[] listPosts)
        {
            if (IsArrayEmpty(listPersonnels))
            {
                return;
            }

            int indexCorrector = 1;

            for (int i = 0; i < listPersonnels.Length; i++)
            {
                Console.WriteLine(i + indexCorrector + ") " + listPersonnels[i] + " - " + listPosts[i]);
            }
        }

        private static void DeletePersonnelInDossier(ref string[] listPersonnels, ref string[] listPosts)
        {
            if (IsArrayEmpty(listPersonnels))
            {
                return;
            }

            int numberOnListDeleted;
            int valueIncreasingArray = -1;
            int indexComponentDeleted;
            int lastIndexArray = listPersonnels.Length - 1;

            WriteAllDossiers(listPersonnels, listPosts);

            Console.Write("\nКого удалить из списка: ");
            numberOnListDeleted = Convert.ToInt32(Console.ReadLine());

            if (numberOnListDeleted <= 0 || numberOnListDeleted > listPersonnels.Length)
            {
                Console.WriteLine("Некорректный ввод");
                return;
            }
            else if (numberOnListDeleted % 1 != 0)
            {
                Console.WriteLine("Некорректный ввод");
                return;
            }

            indexComponentDeleted = numberOnListDeleted - 1;

            for (int i = 0; i < listPersonnels.Length; i++)
            {
                if (i >= indexComponentDeleted && i != lastIndexArray)
                {
                    listPersonnels[i] = listPersonnels[i + 1];
                    listPosts[i] = listPosts[i + 1];
                }
            }

            listPersonnels = ReduceStringArray(listPersonnels, valueIncreasingArray);
            listPosts = ReduceStringArray(listPosts, valueIncreasingArray);
        }

        private static void SearchSurname(string[] listPersonnels, string[] listPosts)
        {
            if (IsArrayEmpty(listPersonnels))
            {
                return;
            }

            string surname;

            bool isSurnameFound = false;

            int indexCorrector = 1;
            int firstSymbolSurnameArray = 0;

            string[] surnameArray;

            Console.Write("Введите фамилию: ");
            surname = Console.ReadLine().ToLower();

            for (int i = 0; i < listPersonnels.Length; i++)
            {
                surnameArray = listPersonnels[i].Split(' ');
                surnameArray[firstSymbolSurnameArray] = surnameArray[firstSymbolSurnameArray].ToLower();

                if (surnameArray[firstSymbolSurnameArray].Contains(surname))
                {
                    Console.WriteLine($"{i + indexCorrector}) {listPersonnels[i]} - {listPosts[i]}");
                    isSurnameFound = true;
                }
            }

            if (!isSurnameFound)
            {
                Console.WriteLine($"{surname} не найден");
            }
        }

        private static bool IsArrayEmpty(string[] listPersonnels)
        {
            if (listPersonnels.Length == 0)
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
