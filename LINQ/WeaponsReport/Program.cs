using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private List<Soldier> _soldiers = new List<Soldier>();

        public Database()
        {
            _soldiers.Add(new Soldier("Вова", "СГК Канарейка", "Майор", 12));
            _soldiers.Add(new Soldier("Петя", "АК-9", "Капитан", 6));
            _soldiers.Add(new Soldier("Витя", "АК-74М", "Рядовой", 24));
            _soldiers.Add(new Soldier("Серёжа", "Пистолет Макарова", "Лейтенант", 15));
            _soldiers.Add(new Soldier("Саша", "М4", "Сержант", 20));
            _soldiers.Add(new Soldier("Рома", "АК47", "Прапорщик", 16));

        }

        public void Work()
        {
            const string ShowSoldiersInformationMenu = "1";
            const string ShowNameRankSoldiersMenu = "2";
            const string ExitMenu = "3";

            bool isWork = true;
            string diciredAction;

            while (isWork == true)
            {
                Console.WriteLine($"{ShowSoldiersInformationMenu} - вывести всю информацию о солдатах.");
                Console.WriteLine($"{ShowNameRankSoldiersMenu} - вывести имя и воинское звание.");
                Console.WriteLine($"{ExitMenu} - выход.");

                Console.Write("\nВведите желаемое действие: ");
                diciredAction = Console.ReadLine();
                Console.WriteLine();

                switch (diciredAction)
                {
                    case ShowSoldiersInformationMenu:
                        ShowSoldiersInformation();
                        break;

                    case ShowNameRankSoldiersMenu:
                        ShowNameRankSoldiers();
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
            }
        }

        private void ShowSoldiersInformation()
        {
            foreach (var soldier in _soldiers)
            {
                soldier.ShowInformation();
            }
        }

        private void ShowNameRankSoldiers()
        {
            var newSoldiers = _soldiers.Select( soldier => new { soldier.Name, soldier.Rank });

            foreach (var soldier in newSoldiers)
            {
                Console.WriteLine($"Имя солдата - {soldier.Name}, звание - {soldier.Rank}");
            }
        }
    }

    class Soldier
    {
        public Soldier(string name, string armament, string title, int serviceLife)
        {
            Name = name;
            Armament = armament;
            Rank = title;
            ServiceLife = serviceLife;
        }

        public string Name { get; private set; }
        public string Armament { get; private set; }
        public string Rank { get; private set; }
        public int ServiceLife { get; private set; }

        public void ShowInformation()
        {
            Console.WriteLine($"Имя солдата - {Name}, вооружение - {Armament}, звание - {Rank}, срок службы - {ServiceLife}.");
        }
    }
}