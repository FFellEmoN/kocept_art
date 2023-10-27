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
                        books.TryGetBook();
                        break;

                    case ShowAllBook:
                        books.ShowAll();
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

                Console.ReadKey();
                Console.Clear();
            } while (isWork);

        }
    }

    class Book
    {
        public Book(string title, string author, string yearRalease)
        {
            Title = title;
            Author = author;
            YearRelease = yearRalease;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string YearRelease { get; private set; }

    }

    class BookStorage
    {
        private static List<Book> _library = new List<Book>();
        private static List<Book> _found = new List<Book>();
        private static List<Book> _tempList = new List<Book>();

        public void AddBook()
        {
            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();
            Console.Write("\nВведите имя автора: ");
            string author = Console.ReadLine();
            Console.Write("\nВведите год издания книги: ");
            string yearRalease = Console.ReadLine();

            _library.Add(new Book(title, author, yearRalease));
        }

        public void TryGetBook()
        {
            int allCoincidence = 0;

            bool includeIndex = false;

            Console.Write("Введите год издания книги: ");
            string year = Console.ReadLine().ToLower();

            TryGet(year, out int coincidence);
            allCoincidence = coincidence;

            Console.WriteLine($"\nНайденно {coincidence} совпадений.");

            Console.Write("\nВведите автора книги: ");
            string author = Console.ReadLine().ToLower();

            TryGet(author, out coincidence);
            allCoincidence += coincidence;

            Console.WriteLine($"\nНайденно {coincidence} совпадений.");

            Console.Write("\nВведите названии книги: ");
            string title = Console.ReadLine().ToLower();

            TryGet(title, out coincidence);
            allCoincidence += coincidence;

            Console.WriteLine($"\nНайденно {coincidence} совпадений.");

            Console.WriteLine($"Вот все найденные книги по вашему запросу {allCoincidence}.\n");
            ShowAllFind(includeIndex);
            _found = new List<Book>();
        }

        private void ShowAllFind(bool triger)
        {
            int index = 1;

            if (triger)
            {
                foreach (Book book in _found)
                {
                    Console.WriteLine($"{_found[index]}) Год: {book.YearRelease}\nАвтор: {book.Author}\nНазвание: {book.Title}");

                    index++;
                }
            }
            else
            {
                foreach (Book book in _found)
                {
                    Console.WriteLine($"Год: {book.YearRelease}\nАвтор: {book.Author}\nНазвание: {book.Title}");
                }
            }
        }

        public void ShowAll()
        {
            foreach (Book book in _library)
            {
                Console.WriteLine($"Год: {book.YearRelease}\nАвтор: {book.Author}\nНазвание: {book.Title}");
            }
        }

        private void TryGet(string line, out int i)
        {
            i = 0;

            if (_found.Count == 0)
            {
                foreach (Book book in _library)
                {
                    if (SearchCriteriaMatch(book, line))
                    {
                        _found.Add(book);
                        i++;
                    }
                }
            }
            else
            {
                foreach (Book book in _found)
                {
                    if (SearchCriteriaMatch(book, line))
                    {
                        _tempList.Add(book);
                        i++;
                    }
                }

                foreach (Book book in _tempList)
                    _found.Add(book);

                _tempList.Clear();
            }
        }

        private bool SearchCriteriaMatch(Book book, string line)
        {
            return book.YearRelease.ToLower() == line || book.Author.ToLower() == line || book.Title.ToLower() == line;
        }

        public void DealetBook()
        {
            bool includeIndex = true;

            Console.WriteLine("Какую книгу удалить ?");
            Console.Write("Введите название: ");
            string titleDelate = Console.ReadLine().ToLower();
            TryGet(titleDelate, out int i);

            ShowAllFind(includeIndex);

            Console.WriteLine("Введите номер книги, которую хотите удалить.");
            int number = Convert.ToInt32(Console.ReadLine());

            foreach (Book book in _library)
            {
                if (_found[number - 1].Equals(book))
                    _library.Remove(book);
            }
        }
    }
}
