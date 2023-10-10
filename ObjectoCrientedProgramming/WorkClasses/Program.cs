using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(1, "SuperMan", "Супер герой с множеством способностей");

            player.ShowInfoPlayer();
        }
    }

    class Player
    {
        private int id;
        private string name;
        private string description;

        public Player(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public void ShowInfoPlayer()
        {
            Console.WriteLine("Информа об игроке");
            Console.WriteLine($"id: {id}\nИмя: {name}\nОписание: {description}.");
        }
    }
}
