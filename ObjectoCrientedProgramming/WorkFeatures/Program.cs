using System;

namespace WorkFeatures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player('@', 30, 5);
            Randerer randerer = new Randerer();

            randerer.Draw(player);
            Console.ReadKey();
        }
    }

    class Player
    {
        public Player(char symbol, int positionX, int positionY)
        {
                Symbol = symbol;
                PositionX = positionX;
                PositionY = positionY;
        }

        public char Symbol { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
    }

    class Randerer
    {
        public void Draw(Player player)
        {
                Console.CursorVisible = false;
                Console.SetCursorPosition(player.PositionX, player.PositionY);
                Console.WriteLine(player.Symbol);
            }
        }
    }
}
