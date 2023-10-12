using System;

namespace WorkClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(1, "SuperMan", "Супер герой с множеством способностей");

            player.ShowInfo();
        }
    }

    class Player
    {
        private int _id;
        private string _name;
        private string _description;

        public Player(int id, string name, string description)
        {
            _id = id;
            _name = name;
            _description = description;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Информа об игроке");
            Console.WriteLine($"_id: {_id}\nИмя: {_name}\nОписание: {_description}.");
        }
    }
}
