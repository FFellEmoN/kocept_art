using System;
using System.Collections.Generic;

namespace BookStorage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddBookMenu = "1";
            const string FindBookMenu = "2";
            const string ShowAllBook = "3";
            const string DeleteBookMenu = "4";
            const string ExitMenu = "5";

            bool isWork = true;

            string desiredAction;

            var books = new BookStorage();

            do
            {
                Console.WriteLine($"{AddBookMenu} - добавить книгу.");
                Console.WriteLine($"{FindBookMenu} - показать книгу по названию, автору, году издания.");
                Console.WriteLine($"{ShowAllBook} - показать все книги.");
                Console.WriteLine($"{DeleteBookMenu} - удалить книгу по номеру.");
                Console.WriteLine($"{ExitMenu} - выйти из приложения");

                Console.Write("Выбирите желаемое действие: ");
                desiredAction = Console.ReadLine();
                Console.WriteLine();

                switch (desiredAction)
                {
                    case AddBookMenu:
                        books.AddBook();
                        break;

                    case FindBookMenu:
                        books.FindBook();
                        break;

                    case ShowAllBook:
                        books.ShowAll();
                        break;

                    case DeleteBookMenu:
                        books.DealetBook();
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

            Console.WriteLine("До свидания!");
            Console.ReadKey();
        }
    }

    class Book
    {
        public Book(string title, string author, string yearRalease, int uniqueCode)
        {
            Title = title;
            Author = author;
            YearRelease = yearRalease;
            UniqueCode = uniqueCode;
        }

        public int UniqueCode { get; private set; }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string YearRelease { get; private set; }

    }

    class BookStorage
    {
        private static List<Book> _library = new List<Book>();

        public void AddBook()
        {
            int uniqueCode = _library.Count;

            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();
            Console.Write("\nВведите имя автора: ");
            string author = Console.ReadLine();
            Console.Write("\nВведите год издания книги: ");
            string yearRalease = Console.ReadLine();

            _library.Add(new Book(title, author, yearRalease, uniqueCode));
        }

        public void FindBook()
        {
            if (_library.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");
                return;
            }

            Console.Write("Введите год издания книги: ");
            string year = Console.ReadLine().ToLower();

            FindYear(year);

            Console.Write("\nВведите автора книги: ");
            string author = Console.ReadLine().ToLower();

            FindAuthor(author);

            Console.Write("\nВведите названии книги: ");
            string title = Console.ReadLine().ToLower();

            FindTitle(title);
        }

        public void ShowAll()
        {
            if (_library.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");
                return;
            }

            foreach (Book book in _library)
            {
                Show(book);
            }
        }

        public void Show(Book book)
        {
            Console.WriteLine($"Код книги: {book.UniqueCode}\nГод: {book.YearRelease}\nАвтор: {book.Author}\nНазвание: {book.Title}\n");
        }

        public void DealetBook()
        {
            if (_library.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");

                return;
            }

            Console.WriteLine("Какую книгу удалить ?");

            ShowAll();

            if (_library.Count > 0)
            {
                Console.WriteLine("Введите код книги, которую хотите удалить.");
                string number = Console.ReadLine();

                if (int.TryParse(number, out int index) && index <= _library.Count && index > 0)
                {
                    foreach (Book book in _library)
                    {
                        if (_library[index].Equals(book))
                        {
                            _library.Remove(book);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели не число или некоректное число.");
                }
            }
            else
            {
                Console.WriteLine("Библиотека пуста.");
            }
        }

        private bool SearchYearMatch(Book book, string year)
        {
            return book.YearRelease.ToLower() == year;
        }

        private bool SearchAuthorMatch(Book book, string author)
        {
            return book.Author.ToLower() == author;
        }

        private bool SearchTitleMatch(Book book, string title)
        {
            return book.Title.ToLower() == title;
        }

        private void FindYear(string year)
        {
            foreach (Book book in _library)
            {
                if (SearchYearMatch(book, year))
                {
                    Console.WriteLine("Подходящие книги по году:");
                    Show(book);
                    break;
                }
            }
        }

        private void FindAuthor(string author)
        {
            foreach (Book book in _library)
            {
                if (SearchAuthorMatch(book, author))
                {
                    Console.WriteLine("Подходящие книги по автору:");
                    Show(book);
                    break;
                }
            }
        }

        private void FindTitle(string title)
        {
            foreach (Book book in _library)
            {
                if (SearchTitleMatch(book, title))
                {
                    Console.WriteLine("Подходящие книги по названию:");
                    Show(book);
                    break;
                }
            }
        }
    }
}