using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddPlayerName = "1";
            const string RemovePlayerName = "2";
            const string BanPlayerName = "3";
            const string UnbanPlayerName = "4";

            string idPlayer;
            string desiredAction;
            string namePlayer;

            bool isWork = true;

            Database database = new Database();

            do
            {
                Console.Write("Выбирите действие: ");
                desiredAction = Console.ReadLine();

                switch (desiredAction)
                {
                    case AddPlayerName:
                        Console.Write("Введите имя игрока: ");
                        namePlayer = Console.ReadLine();

                        database.AddPlayer(new Player(namePlayer));
                        break;
                    case RemovePlayerName:
                        Console.WriteLine("Введите id игрока, которого хотите удалить");
                        idPlayer = Console.ReadLine();

                        if (int.TryParse(idPlayer, out int id) &&
                            id <= database.GetCountListPlayers() &&
                            id >= 0)
                        {
                            database.RemovePlayer(id);
                        }
                        else
                        {
                            Console.WriteLine("Такого Id не существует");
                        }
                        break;
                    case BanPlayerName:
                        Console.WriteLine("")

                }

            } while (true);
        }
    }

    class Player
    {
        public Player(string namePlayer)
        {
            NamePlayer = namePlayer;
        }

        public int IdPlayer { get; set; }

        public int LevelPlayer { get; set; }

        public string NamePlayer { get; private set; }

        public bool IsPlayerBan { get; set; }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();

        public void AddPlayer(Player player)
        {
            Random random = new Random();

            int levelPlayer = random.Next(0, 10);

            player.LevelPlayer = levelPlayer;
            player.IdPlayer = _players.Count;
            _players.Add(player);
        }

        public void RemovePlayer(int idPlayer)
        {
            foreach (Player player in _players)
            {
                if (player.IdPlayer == idPlayer)
                    _players.Remove(player);
            }
        }

        public void BanPlayer(int idPlayer)
        {
            foreach (Player player in _players)
            {
                if (player.IdPlayer == idPlayer)
                    player.IsPlayerBan = true;
            }
        }

        public void UnbanPlayer(int idPlayer)
        {
            foreach (Player player in _players)
            {
                if (player.IdPlayer == idPlayer)
                    player.IsPlayerBan = false;
            }
        }

        public int GetCountListPlayers()
        {
            return _players.Count;
        }
    }
}
