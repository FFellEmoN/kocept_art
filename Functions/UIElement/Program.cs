using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 5;
            int maxHealth = 10;
            int positionX = 0;
            int positionY = 0;
            int procentsHelth = (maxHealth - health) * 10;

            ConsoleColor healthColor = ConsoleColor.Green;
            ConsoleColor procentsColor = ConsoleColor.Red;

            DrawnBar(health, maxHealth, procentsHelth, procentsColor, healthColor, positionX, positionY);
        }

        private static void DrawnBar(int value, int maxValue, int procent, ConsoleColor procentsColor, ConsoleColor healthColor, int positionX, int positionY)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            ConsoleColor defaultTextColor = ConsoleColor.White;

            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar += " ";
            }

            Console.SetCursorPosition(positionX, positionY);
            Console.Write('[');
            Console.BackgroundColor = healthColor;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;

            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += " ";
            }

            Console.Write(bar + ']');
            Console.ForegroundColor = procentsColor;
            Console.Write($" {procent}%");
            Console.ForegroundColor = defaultTextColor;
            Console.WriteLine();
        }
    }
}
