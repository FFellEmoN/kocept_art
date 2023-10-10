using System;

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
        private int _idPlayer;
        private string _namePlayer;
        private string _descriptionPlayer;

        public Player(int id, string name, string description)
        {
            this._idPlayer = id;
            this._namePlayer = name;
            this._descriptionPlayer = description;
        }

        public void ShowInfoPlayer()
        {
            Console.WriteLine("Информа об игроке");
            Console.WriteLine($"_idPlayer: {_idPlayer}\nИмя: {_namePlayer}\nОписание: {_descriptionPlayer}.");
        }
    }
}
