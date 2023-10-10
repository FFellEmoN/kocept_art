using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFeatures
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Player
    {
        public char symbolPlayer { get; private set; }
        public int positionPlayerX { get; private set; }
        public int positionPlayerY { get; private set; }
    }

    class Randerer
    {
        public void Draw(Player player)
        {
            Console.SetCursorPosition(player.positionPlayerX, player.positionPlayerY);
            Console.WriteLine(player.symbolPlayer);
        }
    }
}
