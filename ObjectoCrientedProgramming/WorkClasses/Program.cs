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
        private int idPlayer;
        private string namePlayer;
        private string descriptionPlayer;

        public Player(int id, string name, string description)
        {
            this.idPlayer = id;
            this.namePlayer = name;
            this.descriptionPlayer = description;
        }

        public void ShowInfoPlayer()
        {
            Console.WriteLine("Информа об игроке");
            Console.WriteLine($"idPlayer: {idPlayer}\nИмя: {namePlayer}\nОписание: {descriptionPlayer}.");
        }
    }
}
