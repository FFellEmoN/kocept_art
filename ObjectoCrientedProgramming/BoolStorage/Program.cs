using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace BookStorage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddBookMenu = "1";
            const string FindByTitleMenu = "2";
            const string FindByAuthorMenu = "3";
            const string FindByYearMenu = "4";
            const string ShowAllBook = "5";
            const string DeleteBookMenu = "6";
            const string ExitMenu = "7";
            
            bool isWork = true;

            string desiredAction;

            var bookStrorage = new BookStorage();

            do
            {
                Console.WriteLine($"{AddBookMenu} - добавить книгу.");
                Console.WriteLine($"{FindByTitleMenu} - найти книгу по названию.");
                Console.WriteLine($"{FindByAuthorMenu} - найти книгу по автору.");
                Console.WriteLine($"{FindByYearMenu} - найти книгу по году издания.");
                Console.WriteLine($"{ShowAllBook} - показать все книги.");
                Console.WriteLine($"{DeleteBookMenu} - удалить книгу по номеру.");
                Console.WriteLine($"{ExitMenu} - выйти из приложения");

                Console.Write("Выбирите желаемое действие: ");
                desiredAction = Console.ReadLine();
                Console.WriteLine();

                switch (desiredAction)
                {
                    case AddBookMenu:
                        bookStrorage.AddBook();
                        break;

                    case FindByTitleMenu:
                        bookStrorage.ShowByTitle();
                        break;

                    case FindByAuthorMenu:
                        bookStrorage.ShowByAuthor();
                        break;

                    case FindByYearMenu:
                        bookStrorage.ShowByYear();
                        break;

                    case ShowAllBook:
                        bookStrorage.ShowAll();
                        break;

                    case DeleteBookMenu:
                        bookStrorage.DealetBook();
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
        public Book(string title, string author, int yearRalease)
        {
            Title = title;
            Author = author;
            YearRelease = yearRalease;
        }

        public int YearRelease { get; private set; }

        public string Title { get; private set; }
        public string Author { get; private set; }
    }

    class BookStorage
    {
        private List<Book> _books = new List<Book>();

        public void AddBook()
        {
            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();
            Console.Write("\nВведите имя автора: ");
            string author = Console.ReadLine();
            Console.Write("\nВведите год издания книги: ");
            string year = Console.ReadLine();

            if (int.TryParse(year, out int yearRalease))
            {
                _books.Add(new Book(title, author, yearRalease));
            }
            else
            {
                Console.WriteLine("Вы ввели не число.");
            }
        }

        public void ShowAll()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");
                return;
            }

            for (int i = 0; i < _books.Count; i++)
            {
                Show(_books[i], i);
            }
        }

        public void DealetBook()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");
                return;
            }

            Console.WriteLine("Какую книгу удалить ?");
            ShowAll();

            if (_books.Count > 0)
            {
                Console.WriteLine("Введите код книги, которую хотите удалить.");
                string number = Console.ReadLine();

                if (int.TryParse(number, out int index) && index <= _books.Count && index >= 0)
                {
                    _books.Remove(_books[index]);
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

        public void ShowByYear()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");
                return;
            }

            Console.Write("Введите год издания книги: ");
            string year = Console.ReadLine().ToLower();

            if (int.TryParse(year, out int yearRalease))
            {
                for (int i = 0; i < _books.Count; i++)
                {
                    if (SearchYearMatch(_books[i], yearRalease))
                    {
                        Console.WriteLine("Подходящие книги по году:");
                        Show(_books[i], i);
                    }
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число.");
            }
        }

        public void ShowByAuthor()
        {
            Console.Write("\nВведите автора книги: ");
            string author = Console.ReadLine().ToLower();

            if (_books.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");
                return;
            }

            for (int i = 0; i < _books.Count; i++)
            {
                if (SearchAuthorMatch(_books[i], author))
                {
                    Console.WriteLine("Подходящие книги по автору:");
                    Show(_books[i], i);
                }
            }
        }

        public void ShowByTitle()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");
                return;
            }

            Console.Write("\nВведите названии книги: ");
            string title = Console.ReadLine().ToLower();

            for (int i = 0; i < _books.Count; i++)
            {
                if (SearchTitleMatch(_books[i], title))
                {
                    Console.WriteLine("Подходящие книги по названию:");
                    Show(_books[i], i);
                }
            }
        }

        private bool SearchYearMatch(Book book, int year)
        {
            return book.YearRelease == year;
        }

        private bool SearchAuthorMatch(Book book, string author)
        {
            return book.Author.ToLower() == author;
        }

        private bool SearchTitleMatch(Book book, string title)
        {
            return book.Title.ToLower() == title;
        }

        private void Show(Book book, int index)
        {
            Console.WriteLine($"Код книги: {index}\nГод: {book.YearRelease}\nАвтор: {book.Author}\nНазвание: {book.Title}\n");
        }
    }
}