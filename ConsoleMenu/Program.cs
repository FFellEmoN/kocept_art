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
            const string NumberOfOperationMenu_1 = "1";
            const string NumberOfOperationMenu_2 = "2";
            const string NumberOfOperationMenu_3 = "3";
            const string NumberOfOperationMenu_4 = "4";

            int desiredCollor;
            int windowWidth = 600;
            int windowHeight = 600;

            string desiredOperatoion;

            bool exitProgramTriger = true;

            do
            {
                Console.WriteLine("Выберите необоходимую операцию.");
                Console.WriteLine($"{NumberOfOperationMenu_1} - изменить размер консоли"); ;
                Console.WriteLine($"{NumberOfOperationMenu_2} - изменить цвет консоли");
                Console.WriteLine($"{NumberOfOperationMenu_3} - изменить цвет текста");
                Console.WriteLine($"{NumberOfOperationMenu_4} - выйти из программы");

                Console.Write("Выш выбор: ");
                desiredOperatoion = Console.ReadLine();
                Console.Clear();

                switch (desiredOperatoion)
                {
                    case "1":
                        Console.WriteLine("Введите ширину консоли.");
                        windowWidth = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите высоту консоли");
                        windowHeight = Convert.ToInt32(Console.ReadLine());
                        
                        Console.WindowHeight = windowHeight;
                        Console.WindowWidth = windowWidth;
                        Console.Clear();
                        break;
                    case "2":
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
                    case "3":
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
                    case "4":
                        Console.WriteLine("Всего доброго!");
                        exitProgramTriger = false;
                        break;
                }
            } while (exitProgramTriger);
        }
    }
}
