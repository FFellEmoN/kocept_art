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
                this.symbolPlayer = symbolPlayer;
                this.positionPlayerX = positionPlayerX;
                this.positionPlayerY = positionPlayerY;
        }

        public char symbolPlayer { get; private set; }
        public int positionPlayerX { get; private set; }
        public int positionPlayerY { get; private set; }
    }

    class Randerer
    {
        public void Draw(Player player)
        {
                Console.CursorVisible = false;
                Console.SetCursorPosition(player.positionPlayerX, player.positionPlayerY);
                Console.WriteLine(player.symbolPlayer);
            }
        }
    }
}
