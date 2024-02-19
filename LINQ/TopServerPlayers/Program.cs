using System;
using System.Collections.Generic;
using System.Linq;

namespace TopServerPlayers
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Work();
        }
    }

    class Server
    {
        private List<Player> _players;

        public Server()
        {
            _players = new List<Player>
            {
                new Player("_LEON_", 20, 71),
                new Player("ARBUS", 55, 82),
                new Player("LOL", 56, 78),
                new Player("Win_1", 34, 83),
                new Player("Luti", 86, 94),
                new Player("Dad", 36, 63),
                new Player("Brawler", 46, 86),
                new Player("Toxic", 24, 45),
                new Player("432_", 74, 64),
                new Player("GG_OMG", 35, 74),
                new Player("S_S_S", 168, 75),
                new Player("One1", 234, 111),
                new Player("LiGA", 35, 45)
            };
        }

        public void Work()
        {
            const string ShowTopPlayersByLevelMenu = "1";
            const string ShowTopPlayersByPowerMenu = "2";
            const string ExitMenu = "3";

            bool isWork = true;

            string diciredAction;

            int numberTopPlayers = 3;

            do
            {
                Console.WriteLine($"{ShowTopPlayersByLevelMenu}) - топ {numberTopPlayers} игрока по уровню");
                Console.WriteLine($"{ShowTopPlayersByPowerMenu}) - топ {numberTopPlayers} игрока по силе");
                Console.WriteLine($"{ExitMenu}) - выход.");

                Console.Write("\nВедите желаемое действие: ");
                diciredAction = Console.ReadLine();

                switch (diciredAction)
                {
                    case ShowTopPlayersByLevelMenu:
                        ShowTopPlayersByLevel(numberTopPlayers);
                        break;

                    case ShowTopPlayersByPowerMenu:
                        ShowTopPlayersByPower(numberTopPlayers);
                        break;

                    case ExitMenu:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Не верный ввод, попробуйте еще раз.");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            } while (isWork == true) ;
        }

        private void ShowTopPlayersByLevel(int numberTopPlayers)
        {
            var playersByLevel = _players.OrderByDescending(_patients => _patients.Level).Take(numberTopPlayers).ToList();

            Console.WriteLine($"\nТоп {numberTopPlayers} игрока по уровню:\n");

            ShowPlayersInfo(playersByLevel);
        }

        private void ShowTopPlayersByPower(int numberTopPlayers)
        {
            var playersByPower = _players.OrderByDescending(_patients => _patients.Power).Take(numberTopPlayers).ToList();

            Console.WriteLine($"\nТоп {numberTopPlayers} игрока по силе:\n");

            ShowPlayersInfo(playersByPower);
        }

        private void ShowPlayersInfo(List<Player> players)
        {
            foreach (var player in players)
            {
                player.ShowInfo();
            }
        }
    }

    class Player
    {
        public Player(string name, int level, int power)
        {
            Name = name;
            Level = level;
            Power = power;
        }

        public string Name { get;}
        public int Level { get;}
        public int Power { get;}

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, уровень  - {Level}, сила - {Power}.");
        }
    }
}