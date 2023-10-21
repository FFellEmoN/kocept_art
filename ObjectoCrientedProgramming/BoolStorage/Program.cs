using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Collections.Specialized.BitVector32;

namespace BookStorage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddBookMenu = "1";
            const string GetBookMenu = "2";
            const string ShowAllBook = "3";
            const string DeleteBookMenu = "4";
            const string ExitMenu = "5";

            bool isWork = true;

            string desiredAction;

            var books = new BookStorage();

            do
            {
                Console.WriteLine($"{AddBookMenu} - добавить книгу.");
                Console.WriteLine($"{GetBookMenu} - показать книгу по номеру.");
                Console.WriteLine($"{ShowAllBook} - показать все книги.");
                Console.WriteLine($"{DeleteBookMenu} - удалить книгу по номеру.");

                Console.WriteLine("Выбирите желаемое действие");
                desiredAction = Console.ReadLine();

                switch (desiredAction)
                {
                    case AddBookMenu:
                        books.AddBook();
                        break;

                    case GetBookMenu:
                        break;

                    case ShowAllBook:
                        break;

                    case DeleteBookMenu:
                        break;

                    case ExitMenu:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Действия не существует.");
                        break;
                }
            } while (isWork);

        }
    }

    class Book
    {
        public Book(string name, string author, string yearRalease)
        {
            Name = name;
            Author = author;
            YearRelease = yearRalease;
        }

        public string Name { get; private set; }
        public string Author { get; private set; }
        public string YearRelease { get; private set; }

    }

    class BookStorage
    {
        private static List<Book> _books = new List<Book>();

        public void AddBook()
        {
            Console.Write("Введите название книги: ");
            string name = Console.ReadLine();
            Console.Write("\nВведите имя автора: ");
            string author = Console.ReadLine();
            Console.Write("\nВведите год издания книги: ");
            string yearRalease = Console.ReadLine();

            _books.Add( new Book(name, author, yearRalease) );
        }

        public void GetBook()
        {

        }
    }
}
