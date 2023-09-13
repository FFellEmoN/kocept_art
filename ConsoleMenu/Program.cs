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
            const string ChangeConsoleSizeMenu = "1";
            const string ChangeConsoleCollorMenu = "2";
            const string ChangeTextCollorMenu = "3";
            const string ExitProgramMenu = "4";

            int desiredCollor;
            int windowWidth;
            int windowHeight;
            int answerYellowConsole = 1;
            int answerGrayConsole = 2;
            int answerRedText = 1;
            int answerBlueText = 2;

            string desiredOperatoion;

            bool IsClosing = true;

            do
            {
                Console.WriteLine("Выберите необоходимую операцию.");
                Console.WriteLine($"{ChangeConsoleSizeMenu} - изменить размер консоли"); ;
                Console.WriteLine($"{ChangeConsoleCollorMenu} - изменить цвет консоли");
                Console.WriteLine($"{ChangeTextCollorMenu} - изменить цвет текста");
                Console.WriteLine($"{ExitProgramMenu} - выйти из программы");

                Console.Write("Выш выбор: ");
                desiredOperatoion = Console.ReadLine();
                Console.Clear();

                switch (desiredOperatoion)
                {
                    case ChangeConsoleSizeMenu:
                        Console.WriteLine("Введите ширину консоли.");
                        windowWidth = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите высоту консоли");
                        windowHeight = Convert.ToInt32(Console.ReadLine());
                        
                        Console.WindowHeight = windowHeight;
                        Console.WindowWidth = windowWidth;
                        break;

                    case ChangeConsoleCollorMenu:
                        Console.WriteLine("Выбирите цвет консоли");

                        Console.WriteLine($"{answerYellowConsole} - желтый, {answerGrayConsole} - серый");
                        desiredCollor = Convert.ToInt32(Console.ReadLine());

                        if (desiredCollor == answerYellowConsole)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                        } 

                        if (desiredCollor == answerGrayConsole)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                        }
                        break;

                    case ChangeTextCollorMenu:
                        Console.WriteLine("Выбирите цвет текста");

                        Console.WriteLine($"{answerRedText} - красный, {answerBlueText} - синий");
                        desiredCollor = Convert.ToInt32(Console.ReadLine());

                        if (desiredCollor == answerRedText)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        if(desiredCollor == answerBlueText)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        break;

                    case ExitProgramMenu:
                        Console.WriteLine("Всего доброго!");
                        IsClosing = false;
                        break;
                }
            } while (IsClosing);
        }
    }
}
