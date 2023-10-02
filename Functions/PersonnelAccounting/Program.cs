using System;


namespace PersonnelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddDossierMenu = "1";
            const string WriteAllDossiersMenu = "2";
            const string RemoveDossierMenu = "3";
            const string SearchBySurnameMenu = "4";
            const string ExitMenu = "5";

            string[] fullNames = new string[0];
            string[] posts = new string[0];

            string disiredOperation;

            bool doExit = true;

            do
            {
                Console.WriteLine("Выбирите желаемое действие\n\n");
                Console.WriteLine($"{AddDossierMenu} - добавить досье");
                Console.WriteLine($"{WriteAllDossiersMenu} - вывести все досье");
                Console.WriteLine($"{RemoveDossierMenu} - удалить досье");
                Console.WriteLine($"{SearchBySurnameMenu} - поиск по фамилии");
                Console.WriteLine($"{ExitMenu} - выход");

                Console.Write("\nВведите желаемую операцию: ");
                disiredOperation = Console.ReadLine();

                switch (disiredOperation)
                {
                    case AddDossierMenu:
                        AddDossier(ref fullNames, ref posts);
                        break;

                    case WriteAllDossiersMenu:
                        WriteAllDossiers(fullNames, posts);
                        break;

                    case RemoveDossierMenu:
                        DeleteDossier(ref fullNames, ref posts);
                        break;

                    case SearchBySurnameMenu:
                        SearchSurname(fullNames, posts);
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

            string[] tempArray = new string[lengthArray];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            return tempArray;
        }

        private static string[] ReduceStringArray(string[] array, int numberOnListDeleted)
        {
            int value = -1;
            int indexComponentDeleted = numberOnListDeleted - 1;
            int lengthArray = array.Length + value;
            int startIndex = indexComponentDeleted + 1;

            string[] tempArray = new string[lengthArray];

            for (int i = 0; i < indexComponentDeleted; i++)
            {
                    tempArray[i] = array[i];
            }

            for(int i = startIndex; i < array.Length; i++)
            {
                tempArray[i - 1] = array[i];
            }

            return tempArray;
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

        private static void DeleteDossier(ref string[] fullName, ref string[] posts)
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
