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

            char openBracket = '[';
            char closeBracket = ']';

            int percentsHelth = Convert.ToInt32(health / maxHealth * 100);
            int startValue = 0;

            float divisionPriceBar = maxHealth / size;

            bar = FillLine(startValue, health, divisionPriceBar);

            Console.SetCursorPosition(positionHealthBarX, positionHealthBarY);
            Console.Write(openBracket);
            Console.BackgroundColor = healthColor;
            Console.Write(bar);
            Console.BackgroundColor = defaultColorHealthBar;

            bar = FillLine(health, maxHealth, divisionPriceBar);

            Console.Write(bar + closeBracket);
            Console.ForegroundColor = percentsColor;
            Console.Write($" {percentsHelth}%");
            Console.ForegroundColor = defaultTextColor;
            Console.WriteLine();
        }

        private static string FillLine(float health, float maxHealth, float divisionPrice)
        {
            string spaceChare = " ";
            string lineBar = "";

            maxHealth = maxHealth / divisionPrice;
            health = health / divisionPrice;

            for (float i = health; i < maxHealth; i++)
            {
                lineBar += spaceChare;
            }

            return lineBar;
        }
    }
}
