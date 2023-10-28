using System;
using System.Collections.Generic;

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
                Console.WriteLine($"{GetBookMenu} - показать книгу по названию, автору, году издания.");
                Console.WriteLine($"{ShowAllBook} - показать все книги.");
                Console.WriteLine($"{DeleteBookMenu} - удалить книгу по номеру.");

                Console.Write("Выбирите желаемое действие: ");
                desiredAction = Console.ReadLine();
                Console.WriteLine();

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
            string conditionYear = "0";
            string conditionAuthor = "1";
            string conditionTitle = "2";

            bool includeIndex = false;

            Console.Write("Введите год издания книги: ");
            string year = Console.ReadLine().ToLower();

            TryGet(year, conditionYear);

            Console.WriteLine($"\nВсего найденно {_found.Count} совпадений.");

            Console.Write("\nВведите автора книги: ");
            string author = Console.ReadLine().ToLower();

            TryGet(author, conditionAuthor);

            Console.WriteLine($"\nВсего найденно {_found.Count} совпадений.");

            Console.Write("\nВведите названии книги: ");
            string title = Console.ReadLine().ToLower();

            TryGet(title, conditionTitle);

            Console.WriteLine($"\nВсего найденно {_found.Count} совпадений.");

            Console.WriteLine("Совпадения: ");
            ShowAllFind(includeIndex);

            _found = new List<Book>();
        }

        public void ShowAll()
        {
            foreach (Book book in _library)
            {
                Console.WriteLine($"Год: {book.YearRelease}\nАвтор: {book.Author}\nНазвание: {book.Title}\n");
            }
        }

        public void DealetBook()
        {
            string conditinTitle = "2";

            bool includeIndex = true;

            Console.WriteLine("Какую книгу удалить ?");

            Console.Write("Введите название: ");
            string titleDelate = Console.ReadLine().ToLower();

            TryGet(titleDelate, conditinTitle);

            if (_found.Count > 0)
            {
                ShowAllFind(includeIndex);

                Console.WriteLine("Введите номер книги, которую хотите удалить.");
                string number = Console.ReadLine();

                if (int.TryParse(number, out int index) && index <= _found.Count && index > 0)
                {
                    foreach (Book book in _library)
                    {
                        if (_found[index - 1].Equals(book))
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

                _found = new List<Book>();
            }
            else
            {
                Console.WriteLine("Ни одной книги не найдено.");
            }
        }

        private bool SearchCriteriaMatch(Book book, string line, string conditionNumber)
        {
            const string Year = "0";
            const string Author = "1";
            const string Title = "2";

            bool isHave = false;

            switch (conditionNumber)
            {
                case Year:
                    isHave = book.YearRelease.ToLower() == line;
                    break;

                case Author:
                    isHave = book.Author.ToLower() == line;
                    break;

                case Title:
                    isHave = book.Title.ToLower() == line;
                    break;

                default:
                    Console.WriteLine("Условия не существует.");
                    break;
            }

            return isHave;
        }

        private void ShowAllFind(bool triger)
        {
            if (triger)
            {
                foreach (Book book in _found)
                {
                    Console.WriteLine($"{_found.IndexOf(book) + 1}) Год: {book.YearRelease}\n   Автор: {book.Author}\n   Название: {book.Title}\n");
                }
            }
            else
            {
                foreach (Book book in _found)
                {
                    Console.WriteLine($"Год: {book.YearRelease}\nАвтор: {book.Author}\nНазвание: {book.Title}\n");
                }
            }
        }

        /// <summary>
        /// Добовляет в список найденные книги из библиотеки по указанным параметрам. 
        /// Для поиск по году  conditionNumber = 0.
        /// Для поиск по автору  conditionNumber = 1.
        /// Для поиск по названию  conditionNumber = 2.
        /// </summary>
        /// <param name="line">Строка по которой ведется поиск</param>
        /// /// <param name="conditionNumber">Желаемое условие поиска</param>
        private void TryGet(string line, string conditionNumber)
        {
            if (_found.Count == 0)
            {
                foreach (Book book in _library)
                {
                    if (SearchCriteriaMatch(book, line, conditionNumber))
                    {
                        _found.Add(book);
                    }
                }
            }
            else
            {
                foreach (Book book in _found)
                {
                    if (SearchCriteriaMatch(book, line, conditionNumber))
                    {
                        if (_found.Contains(book) == false)
                        {
                            _tempList.Add(book);
                        }
                    }
                }

                foreach (Book book in _tempList)
                    _found.Add(book);

                _tempList.Clear();
            }
        }
    }
}
