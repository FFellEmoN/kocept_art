using System;
using System.Collections.Generic;
using System.Linq;
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
                    case 1:
                        listPersonnels = AddPersonnelsInDossier(listPersonnels);
                        listPosts = AddPostInDossier(listPosts);
                        break;

                    case 2:
                        WriteAllDossiers(listPersonnels, listPosts);
                        break;

                    case 3:

                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    default:
                        Console.WriteLine("\nТакой операции не существует\n");
                        break;
                }

            } while (disiredOperation != ExitMenu);
        }

        private static string[] AddPersonnelsInDossier(string[] listPersonnels)
        {
            string[] array = ResizeArray(listPersonnels);
            int lastIndexArray = array.Length - 1;

            Console.Write("Введите фамилию: ");
            string surname = Console.ReadLine();
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите отчество: ");
            string patronymic = Console.ReadLine();

            string fullName = surname + " " + name + " " + patronymic;
            array[lastIndexArray] = fullName;

            return array;
        }

        private static string[] AddPostInDossier(string[] listPosts)
        {
            string[] array = ResizeArray(listPosts);
            int lastIndexArray = array.Length - 1;

            Console.Write("Введите должность: ");
            string post = Console.ReadLine();

            array[lastIndexArray] = post;

            return array;
        }

        private static string[] ResizeArray(string[] array)
        {
            int valueIncreasingArray = 1;
            int lengthArray = array.Length + valueIncreasingArray;

            string[] newArray = new string[lengthArray];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }

        private static void WriteAllDossiers(string[] personnels, string[] posts)
        {
            int indexCorrector = 1;

            for (int i = 0; i < personnels.Length; i++)
            {
                Console.WriteLine(i + indexCorrector + ") " + personnels[i] + " - " + posts[i]);
            }
        }
    }
}
