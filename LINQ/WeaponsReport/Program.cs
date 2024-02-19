using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Weapons
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            database.Work();
        }
    }

    class Database
    {
        private List<Soldier> _soldiers;

        public Database()
        {
            _soldiers = new List<Soldier>
            {
                new Soldier("Вова", "СГК Канарейка", "Майор", 12),
                new Soldier("Петя", "АК-9", "Капитан", 6),
                new Soldier("Витя", "АК-74М", "Рядовой", 24),
                new Soldier("Серёжа", "Пистолет Макарова", "Лейтенант", 15),
                new Soldier("Саша", "М4", "Сержант", 20),
                new Soldier("Рома", "АК47", "Прапорщик", 16)
            };
        }

        public void Work()
        {
            const string ShowSoldiersInformationMenu = "1";
            const string ShowNamesRanksSoldiersMenu = "2";
            const string ExitMenu = "3";

            bool isWork = true;

            string diciredAction;

            do
            {
                Console.WriteLine($"{ShowSoldiersInformationMenu} - вывести всю информацию о солдатах.");
                Console.WriteLine($"{ShowNamesRanksSoldiersMenu} - вывести имя и воинское звание.");
                Console.WriteLine($"{ExitMenu} - выход.");

                Console.Write("\nВведите желаемое действие: ");
                diciredAction = Console.ReadLine();
                Console.WriteLine();

                switch (diciredAction)
                {
                    case ShowSoldiersInformationMenu:
                        ShowSoldiersInformation();
                        break;

                    case ShowNamesRanksSoldiersMenu:
                        ShowNamesRanksSoldiers();
                        break;

                    case ExitMenu:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Не верный ввод");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();
                Console.Clear();
            } while (isWork);
        }

        private void ShowSoldiersInformation()
        {
            foreach (var soldier in _soldiers)
            {
                soldier.ShowInformation();
            }
        }

        private void ShowNamesRanksSoldiers()
        {
            var newSoldiers = _soldiers.Select(soldier => new { soldier.Name, soldier.Rank });

            foreach (var soldier in newSoldiers)
            {
                Console.WriteLine($"Имя солдата - {soldier.Name}, звание - {soldier.Rank}");
            }
        }
    }

    class Soldier
    {
        public Soldier(string name, string armament, string rank, int serviceLife)
        {
            Name = name;
            Armament = armament;
            Rank = rank;
            ServiceLife = serviceLife;
        }

        public string Name { get; }
        public string Armament { get; }
        public string Rank { get; }
        public int ServiceLife { get; }

        public void ShowInformation()
        {
            Console.WriteLine($"Имя солдата - {Name}, вооружение - {Armament}, звание - {Rank}, срок службы - {ServiceLife}.");
        }
    }
}