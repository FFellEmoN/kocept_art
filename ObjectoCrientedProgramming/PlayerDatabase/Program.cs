using System;
using System.Collections.Generic;

namespace PlayerDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddPlayerMenu = "1";
            const string RemovePlayerMenu = "2";
            const string BanPlayerMenu = "3";
            const string UnbanPlayerMenu = "4";
            const string ShowAllPlayersMenu = "5";
            const string ExitMenu = "6";

            string desiredAction;

            bool isWork = true;

            Database database = new Database();

            do
            {
                Console.WriteLine($"{AddPlayerMenu} - добавить игрока");
                Console.WriteLine($"{RemovePlayerMenu} - удалить игрока");
                Console.WriteLine($"{BanPlayerMenu} - забанить игрока");
                Console.WriteLine($"{UnbanPlayerMenu} - разбанить игрока");
                Console.WriteLine($"{ShowAllPlayersMenu} - показать всех игроков");
                Console.WriteLine($"{ExitMenu} - закрыть программу");

                Console.Write("\nВыбирите действие: ");
                desiredAction = Console.ReadLine();

                switch (desiredAction)
                {
                    case AddPlayerMenu:
                        database.AddPlayer();
                        break;

                    case RemovePlayerMenu:
                        database.RemovePlayer();
                        break;

                    case BanPlayerMenu:
                        database.BanPlayer();
                        break;

                    case UnbanPlayerMenu:
                        database.UnbanPlayer();
                        break;

                    case ShowAllPlayersMenu:
                        database.ShowAllPlayers();
                        break;

                    case ExitMenu:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Такой команды не существует!");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();
                Console.Clear();
            } while (isWork);

            Console.WriteLine("Досвидания!");
        }
    }

    class Player
    {
        public Player(string name, int id)
        {
            Name = name;
            Id = id + 1;
        }

        public int Id { get; private set; }

        public int Level { get; private set; }

        public string Name { get; private set; }

        public bool IsBan { get; private set; }

        public void Ban()
        {
            IsBan = true;
        }

        public void Unban()
        {
            IsBan = false;
        }

        public void SetLevel(int level)
        {
            Level = level;
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();

        private int _idPlayer;

        public void AddPlayer()
        {
            Console.Write("Введите имя игрока: ");
            string namePlayer = Console.ReadLine();

            Random random = new Random();

            Player player = new Player(namePlayer, _idPlayer);
            _idPlayer++;

            int levelPlayer = random.Next(0, 10);

            player.SetLevel(levelPlayer);
            _players.Add(player);
        }

        public void RemovePlayer()
        {
            if (_players.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            Console.WriteLine("Удалить игрока\n");

            ShowAllPlayers();

            if (TryGetPlayer(_players, out Player player))
            {
                _players.Remove(player);
            }
        }

        public void BanPlayer()
        {
            if (_players.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            Console.WriteLine("Заблокировать игрока!\n");

            ShowAllPlayers();

            if (TryGetPlayer(_players, out Player player))
            {
                if (player.IsBan == false)
                {
                    player.Ban();
                    Console.WriteLine($"Игрок: {player.Name}\nid:{player.Id}\nЗаблокирован!");
                }
                else
                {
                    Console.WriteLine("Игрок уже заблокирован!");
                }
            }
        }

        public void UnbanPlayer()
        {
            if (_players.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            Console.WriteLine("Разблокировка игрока\n");

            ShowAllPlayers();

            if (TryGetPlayer(_players, out Player player))
            {
                if (player.IsBan == true)
                {
                    player.Unban();
                    Console.WriteLine($"Игрок: {player.Name}\nid:{player.Id}\nРазблокирован!");
                }
                else
                    Console.WriteLine("Игрок не был заблокирован!");
            }
        }

        public bool CheckingCorrectnessId(string idPlayer, out int id)
        {
            if (int.TryParse(idPlayer, out id))
            {
                if (id > 0)
                    return true;
                else
                {
                    Console.WriteLine("id не может существовать!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число.");
                return false;
            }
        }

        public void ShowAllPlayers()
        {
            foreach (Player player in _players)
            {
                Console.WriteLine($"Игрок: {player.Name} id:{player.Id}");
            }
        }

        private bool TryGetPlayer(List<Player> players, out Player objPlayer)
        {
            Console.Write("Введите id игрока: ");
            string idPlayer = Console.ReadLine();

            if (CheckingCorrectnessId(idPlayer, out int id))
            {
                foreach (Player player in players)
                {
                    if (player.Id == id)
                    {
                        objPlayer = player;
                        return true;
                    }
                }
            }

            Console.WriteLine("Игрок не найден.");

            objPlayer = null;
            return false;
        }
    }
}