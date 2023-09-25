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
            float health = 40;
            float maxHealth = 560;

            int positionX = 0;
            int positionY = 0;
            int sizeBar = 10;

            ConsoleColor healthColor = ConsoleColor.Green;
            ConsoleColor percentsColor = ConsoleColor.Red;

            DrawBar(sizeBar, health, maxHealth, percentsColor, healthColor, positionX, positionY);
        }

        private static void DrawBar(int size, float value, float maxValue, ConsoleColor percentsColor, ConsoleColor healthColor, int positionX, int positionY)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            ConsoleColor defaultTextColor = ConsoleColor.White;

            string bar = "";

            int percentsHelth = Convert.ToInt32(value / maxValue * 100);
            int startValue = 0;
            float divisionPrice = maxValue / size;

            //for (int i = 0; i < value; i++)
            //{
            //    bar += " ";
            //}
            bar = fillingLine(bar, startValue, value, divisionPrice);

            Console.SetCursorPosition(positionX, positionY);
            Console.Write('[');
            Console.BackgroundColor = healthColor;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;

            //bar = "";

            //for (int i = value; i < maxValue; i++)
            //{
            //    bar += " ";
            //}
            bar = fillingLine(bar, value, maxValue, divisionPrice);

            Console.Write(bar + ']');
            Console.ForegroundColor = percentsColor;
            Console.Write($" {percentsHelth}%");
            Console.ForegroundColor = defaultTextColor;
            Console.WriteLine();
        }

        private static string fillingLine(string line, float startValue, float finishValue, float divisionPrice)
        {
            line = "";

            finishValue = finishValue / divisionPrice;
            startValue = startValue / divisionPrice;

            for (float i = startValue; i < finishValue; i++)
            {
                line += " ";
            }

            return line;
        }
    }
}
