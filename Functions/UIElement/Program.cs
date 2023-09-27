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

            int positionHealthBarX = 0;
            int positionHealthBarY = 0;
            int sizeBar = 10;

            ConsoleColor healthColor = ConsoleColor.Green;
            ConsoleColor percentsColor = ConsoleColor.Red;

            DrawBar(sizeBar, health, maxHealth, percentsColor, healthColor, positionHealthBarX, positionHealthBarY);
        }

        private static void DrawBar(int size, float health, float maxHealth, ConsoleColor percentsColor, ConsoleColor healthColor, int positionHealthBarX, int positionHealthBarY)
        {
            ConsoleColor defaultColorHealthBar = Console.BackgroundColor;
            ConsoleColor defaultTextColor = ConsoleColor.White;

            string bar = "";

            int percentsHelth = Convert.ToInt32(health / maxHealth * 100);
            int startValue = 0;

            float divisionPriceBar = maxHealth / size;

            bar = fillingLine(startValue, health, divisionPriceBar);

            Console.SetCursorPosition(positionHealthBarX, positionHealthBarY);
            Console.Write('[');
            Console.BackgroundColor = healthColor;
            Console.Write(bar);
            Console.BackgroundColor = defaultColorHealthBar;

            bar = fillingLine(health, maxHealth, divisionPriceBar);

            Console.Write(bar + ']');
            Console.ForegroundColor = percentsColor;
            Console.Write($" {percentsHelth}%");
            Console.ForegroundColor = defaultTextColor;
            Console.WriteLine();
        }

        private static string fillingLine(float health, float maxHealth, float divisionPrice)
        {
            string lineBar = "";

            maxHealth = maxHealth / divisionPrice;
            health = health / divisionPrice;

            for (float i = health; i < maxHealth; i++)
            {
                lineBar += " ";
            }

            return lineBar;
        }
    }
}
