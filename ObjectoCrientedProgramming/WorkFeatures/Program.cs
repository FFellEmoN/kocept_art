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
        public Player(char symbolPlayer, int positionPlayerX, int positionPlayerY)
        {
                SymbolPlayer = symbolPlayer;
                PositionPlayerX = positionPlayerX;
                PositionPlayerY = positionPlayerY;
        }

        public char SymbolPlayer { get; private set; }
        public int PositionPlayerX { get; private set; }
        public int PositionPlayerY { get; private set; }
    }

    class Randerer
    {
        public void Draw(Player player)
        {
                Console.CursorVisible = false;
                Console.SetCursorPosition(player.PositionPlayerX, player.PositionPlayerY);
                Console.WriteLine(player.SymbolPlayer);
            }
        }
    }
}
