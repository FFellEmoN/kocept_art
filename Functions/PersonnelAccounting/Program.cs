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

            string[] fullNames = new string[0];
            string[] posts = new string[0];

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
                        AddDossier(ref fullNames, ref posts);
                        break;

                    case WriteAllDossiersMenu:
                        WriteAllDossiers(fullNames, posts);
                        break;

                    case RemoveDossierMenu:
                        DeletePersonnelInDossier(ref fullNames, ref posts);
                        break;

                    case SearchBySurnameMenu:
                        SearchSurname(fullNames, posts);
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
            listPersonnels = IncreaseStringArray(listPersonnels);
            listPosts = IncreaseStringArray(listPosts);
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

        private static string[] IncreaseStringArray(string[] array)
        {
            int value = 1;
            int lengthArray = array.Length + value;

            string[] newArray = new string[lengthArray];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        private static string[] ReduceStringArray(string[] array, int numberOnListDeleted)
        {
            int value = -1;
            int indexComponentDeleted = numberOnListDeleted - 1;
            int lastIndexArray = array.Length - 1;
            int lengthArray = array.Length + value;

            string[] newArray = new string[lengthArray];

            for (int i = 0; i < newArray.Length; i++)
            {
                if (i >= indexComponentDeleted)
                    newArray[i] = array[i + 1];
                else
                    newArray[i] = array[i];
            }

            return newArray;
        }

        private static void WriteAllDossiers(string[] fullName, string[] posts)
        {
            if (IsArrayEmpty(fullName))
                return;

            int indexCorrector = 1;

            for (int i = 0; i < fullName.Length; i++)
            {
                Console.WriteLine(i + indexCorrector + ") " + fullName[i] + " - " + posts[i]);
            }
        }

        private static void DeletePersonnelInDossier(ref string[] fullName, ref string[] posts)
        {
            if (IsArrayEmpty(fullName))
                return;

            int numberOnListDeleted;

            WriteAllDossiers(fullName, posts);

            Console.Write("\nКого удалить из списка: ");
            numberOnListDeleted = Convert.ToInt32(Console.ReadLine());

            if (numberOnListDeleted <= 0 || numberOnListDeleted > fullName.Length)
            {
                Console.WriteLine("Некорректный ввод");
                return;
            }
            else if (numberOnListDeleted % 1 != 0)
            {
                Console.WriteLine("Некорректный ввод");
                return;
            }

            fullName = ReduceStringArray(fullName, numberOnListDeleted);
            posts = ReduceStringArray(posts, numberOnListDeleted);
        }

        private static void SearchSurname(string[] fullName, string[] posts)
        {
            if (IsArrayEmpty(fullName))
                return;

            string surname;

            bool isSurnameFound = false;

            int indexCorrector = 1;
            int firstSymbolSurnameArray = 0;

            char splitChar = ' ';

            string[] surnameArray;

            Console.Write("Введите фамилию: ");
            surname = Console.ReadLine().ToLower();

            for (int i = 0; i < fullName.Length; i++)
            {
                surnameArray = fullName[i].Split(splitChar);
                surnameArray[firstSymbolSurnameArray] = surnameArray[firstSymbolSurnameArray].ToLower();

                if (surnameArray[firstSymbolSurnameArray].Contains(surname))
                {
                    Console.WriteLine($"{i + indexCorrector}) {fullName[i]} - {posts[i]}");
                    isSurnameFound = true;
                }
            }

            if (isSurnameFound == false)
            {
                Console.WriteLine($"{surname} не найден");
            }
        }

        private static bool IsArrayEmpty(string[] fullName)
        {
            if (fullName.Length == 0)
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
