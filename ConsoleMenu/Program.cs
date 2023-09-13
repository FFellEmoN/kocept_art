using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ChangeTheConsoleSize = "1";
            const string ChangeTheConsoleCollor = "2";
            const string ChangeTheTextCollor = "3";
            const string ExitTheProgram = "4";

            int desiredCollor;
            int windowWidth;
            int windowHeight;

            string desiredOperatoion;

            bool exitProgramTriger = true;

            do
            {
                Console.WriteLine("Выберите необоходимую операцию.");
                Console.WriteLine($"{ChangeTheConsoleSize} - изменить размер консоли"); ;
                Console.WriteLine($"{ChangeTheConsoleCollor} - изменить цвет консоли");
                Console.WriteLine($"{ChangeTheTextCollor} - изменить цвет текста");
                Console.WriteLine($"{ExitTheProgram} - выйти из программы");

                Console.Write("Выш выбор: ");
                desiredOperatoion = Console.ReadLine();
                Console.Clear();

                switch (desiredOperatoion)
                {
                    case ChangeTheConsoleSize:
                        Console.WriteLine("Введите ширину консоли.");
                        windowWidth = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите высоту консоли");
                        windowHeight = Convert.ToInt32(Console.ReadLine());
                        
                        Console.WindowHeight = windowHeight;
                        Console.WindowWidth = windowWidth;
                        Console.Clear();
                        break;
                    case ChangeTheConsoleCollor:
                        Console.WriteLine("Выбирите цвет консоли");

                        Console.WriteLine("1 - желтый, 2 - серый");
                        desiredCollor = Convert.ToInt32(Console.ReadLine());

                        if (desiredCollor == 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Clear();
                        } else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Clear();
                        }
                        break;
                    case ChangeTheTextCollor:
                        Console.WriteLine("Выбирите цвет текста");

                        Console.WriteLine("1 - красный, 2 - синий");
                        desiredCollor = Convert.ToInt32(Console.ReadLine());

                        if (desiredCollor == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Clear();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Clear();
                        }
                        Console.Clear();
                        break;
                    case ExitTheProgram:
                        Console.WriteLine("Всего доброго!");
                        exitProgramTriger = false;
                        break;
                }
            } while (exitProgramTriger);
        }
    }
}
