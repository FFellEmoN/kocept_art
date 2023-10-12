using System;
using System.Collections.Generic;

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
            const string ExitName = "5";

            string desiredAction;

            bool isWork = true;

            Database database = new Database();

            do
            {
                Console.WriteLine($"{AddPlayerName} - добавить игрока");
                Console.WriteLine($"{RemovePlayerName} - удалить игрока");
                Console.WriteLine($"{BanPlayerName} - забанить игрока");
                Console.WriteLine($"{UnbanPlayerName} - разбанить игрока");
                Console.WriteLine($"{ExitName} - закрыть программу");

                Console.Write("\nВыбирите действие: ");
                desiredAction = Console.ReadLine();

                switch (desiredAction)
                {
                    case AddPlayerName:
                        database.AddPlayer();
                        break;

                    case RemovePlayerName:
                        database.RemovePlayer();
                        break;

                    case BanPlayerName:
                        database.BanPlayer();
                        break;

                    case UnbanPlayerName:
                        database.UnbanPlayer();
                        break;

                    case ExitName:
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
        public Player(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public int Level { get; set; }

        public string Name { get; private set; }

        public bool IsBan { get; set; }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();
        private List<Player> _banPlayers = new List<Player>();

        private string _idPlayer;
        private bool _isExist = false;

        public void AddPlayer()
        {
            Console.Write("Введите имя игрока: ");
            string namePlayer = Console.ReadLine();

            Random random = new Random();

            Player player = new Player(namePlayer);

            int levelPlayer = random.Next(0, 10);

            player.Level = levelPlayer;
            player.Id = _players.Count;
            _players.Add(player);
        }

        public void RemovePlayer()
        {
            if (_players.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            ShowAllPlayers(_players);

            Console.WriteLine("Введите id игрока, которого хотите удалить.");
            string idPlayer = Console.ReadLine();

            if (CheckingCorrectnessId(idPlayer, out int id))
            {
                foreach (Player player in _players)
                {
                    if (player.Id == id)
                    {
                        _players.Remove(player);
                        _isExist = true;
                        break;
                    }
                }
                if (_isExist == false)
                    Console.WriteLine("Игрок не найден.");

                _isExist = false;
            }
            else
            {
                Console.WriteLine("Такого Id не существует.");
            }
        }

        public void BanPlayer()
        {
            if (_players.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            ShowAllPlayers(_players);

            Console.WriteLine("Введите id игрока, которого необходимо заблокировать.");
            _idPlayer = Console.ReadLine();

            if (CheckingCorrectnessId(_idPlayer, out int id))
            {
                foreach (Player player in _players)
                {
                    if (player.Id == id)
                    {
                        _isExist = true;

                        if (player.IsBan == false)
                        {
                            player.IsBan = true;
                            _banPlayers.Add(player);
                            Console.WriteLine($"Игрок: {player.Name}\nid:{player.Id}\nЗаблокирован!");
                        }
                        else
                        {
                            Console.WriteLine("Игрок уже заблокирован!");
                        }
                    }
                }
                if (_isExist == false)
                {
                    Console.WriteLine("Игрок не найден.");
                }

                _isExist = false;
            }
            else
            {
                Console.WriteLine("Вы ввели не число.");
            }
        }

        public void UnbanPlayer()
        {
            if (_banPlayers.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            ShowAllPlayers(_banPlayers);

            Console.WriteLine("Введите id игрока, которого необходимо разблокировать.");
            _idPlayer = Console.ReadLine();

            if (CheckingCorrectnessId(_idPlayer, out int id))
            {
                foreach (Player player in _banPlayers)
                {
                    if (player.Id == id)
                    {
                        player.IsBan = false;
                        _banPlayers.Remove(player);
                        Console.WriteLine($"Игрок: {player.Name}\nid:{player.Id}\nРазблокирован!");
                        _isExist = true;
                        break;
                    }
                }

                if (_isExist == false)
                {
                    Console.WriteLine("Игрок не найден.");
                }

                _isExist = false;
            }
            else
            {
                Console.WriteLine("Вы ввели не число.");
            }
        }

        public bool CheckingCorrectnessId(string idPlayer, out int id)
        {
            return int.TryParse(idPlayer, out id) &&
                            id <= _players.Count &&
                            id >= 0;
        }

        private void ShowAllPlayers(List<Player> list)
        {
            foreach (Player player in list)
            {
                Console.WriteLine($"Игрок: {player.Name} id:{player.Id}");
            }
        }
    }
}