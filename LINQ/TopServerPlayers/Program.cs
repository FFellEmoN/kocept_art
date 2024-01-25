using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private List<Player> _players = new List<Player>();

        public Server()
        {
            _players.Add(new Player("_LEON_", 20, 71));
            _players.Add(new Player("ARBUS", 55, 82));
            _players.Add(new Player("LOL", 56, 78));
            _players.Add(new Player("Win_1", 34, 83));
            _players.Add(new Player("Luti", 86, 94));
            _players.Add(new Player("Dad", 36, 63));
            _players.Add(new Player("Brawler", 46, 86));
            _players.Add(new Player("Toxic", 24, 45));
            _players.Add(new Player("432_", 74, 64));
            _players.Add(new Player("GG_OMG", 35, 74));
            _players.Add(new Player("S_S_S", 168, 75));
            _players.Add(new Player("One1", 234, 111));
            _players.Add(new Player("LiGA", 35, 45));
        }

        public void Work()
        {
            const string ShowTopPlayersByLevelMenu = "1";
            const string ShowTopPlayersByPowerMenu = "2";
            const string ExitMenu = "3";

            bool isWork = true;

            string diciredAction;

            do
            {
                Console.WriteLine($"{ShowTopPlayersByLevelMenu}) - топ 3 игрока по уровню");
                Console.WriteLine($"{ShowTopPlayersByPowerMenu}) - топ 3 игрока по силе");
                Console.WriteLine($"{ExitMenu}) - выход.");

                Console.Write("\nВедите желаемое действие: ");
                diciredAction = Console.ReadLine();

                switch (diciredAction)
                {
                    case ShowTopPlayersByLevelMenu:
                        ShowPlayersByLevel();
                        break;

                    case ShowTopPlayersByPowerMenu:
                        ShowPlayersByPower();
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

        private void ShowPlayersByLevel()
        {
            int numberTopPlayers = 3;

            var playersByLevel = _players.OrderByDescending(_patients => _patients.Level).Take(numberTopPlayers).ToList();

            Console.WriteLine($"\nТоп {numberTopPlayers} игрока по уровню:\n");

            ShowInfo(playersByLevel);
        }

        private void ShowPlayersByPower()
        {
            int numberTopPlayers = 3;

            var playersByPower = _players.OrderByDescending(_patients => _patients.Power).Take(numberTopPlayers).ToList();

            Console.WriteLine($"\nТоп {numberTopPlayers} игрока по силе:\n");

            ShowInfo(playersByPower);
        }

        private void ShowInfo(List<Player> players)
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

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, уровень  - {Level}, сила - {Power}.");
        }
    }
}