using System;
using System.Collections.Generic;

namespace Shoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string OpenShoopMenu = "1";
            const string ShowItemsPlayrMenu = "2";
            const string ShowSallerMoneyMenu = "3";
            const string ShowPlayerMoneyMenu = "4";
            const string ExitMenu = "5";

            string diciredAction;
            bool IsExit = true;

            Player player = new Player();

            Saller saller = new Saller();

            Shoop shoop = new Shoop(saller, player);
            do
            {
                Console.WriteLine($"{OpenShoopMenu}) - открыть магазин.");
                Console.WriteLine($"{ShowItemsPlayrMenu}) - показать предметы игрока.");
                Console.WriteLine($"{ShowSallerMoneyMenu}) - показать деньги {saller.Name}.");
                Console.WriteLine($"{ShowPlayerMoneyMenu}) - показать деньги {player.Name}.");
                Console.WriteLine($"{ExitMenu}) - выйти.");

                Console.Write("\nВведите желаемое действие: ");
                diciredAction = Console.ReadLine();
                Console.WriteLine();

                switch (diciredAction)
                {
                    case OpenShoopMenu:
                        shoop.Open();
                        break;

                    case ShowItemsPlayrMenu:
                        player.ShowItems();
                        break;

                    case ShowSallerMoneyMenu:
                        saller.ShowMoney();
                        break;

                    case ShowPlayerMoneyMenu:
                        player.ShowMoney();
                        break;

                    case ExitMenu:
                        IsExit = false;
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();
                Console.Clear();
            } while (IsExit);
        }
    }

    class Shoop
    {
        private Saller _saller;
        private Player _player;
        public Shoop(Saller saller, Player player)
        {
            _saller = saller;
            _player = player;

            _saller.AddItem(new Item("меч", 15));
            _saller.AddItem(new Item("топор", 20));
        }

        public void Open()
        {
            string disiredItem;

            _saller.ShowMoney();
            _player.ShowMoney();
            Console.WriteLine("\nКакой товар вы хотите приобрести ?\n");
            _saller.ShowItems();

            Console.Write("\nВведите номер товара:");
            disiredItem = Console.ReadLine();

            if (int.TryParse(disiredItem, out int number) &&
                number > 0 &&
                number <= _saller.GetCountItems())
            {
                if (_player.BuyItem(_saller.GetItem(number)))
                {
                    _saller.SellItem(number);
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число или некоректное число.");
            }
        }
    }

    class Item
    {
        public Item(string name, float coast)
        {
            Name = name;
            Coast = coast;
        }

        public string Name { get; private set; }

        public float Coast { get; private set; }

        public override string ToString()
        {
            return $"Товар: {Name}, Цена: {Coast}";
        }
    }

    class TradeCharacter
    {
        protected List<Item> Items;

        protected TradeCharacter()
        {
            Items = new List<Item>();
        }

        public float Money { get; protected set; }

        public string Name { get; protected set; }

        public int GetCountItems()
        {
            return Items.Count;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public virtual void ShowItems()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {Items[i].ToString()}");
            }
        }

        public void ShowMoney()
        {
            Console.WriteLine($"Деньги {Name}: " + Money);
        }
    }

    class Saller : TradeCharacter
    {
        public Saller()
        {
            Money = 300f;
            Name = "Торговец";
        }

        public void SellItem(int number)
        {

            if (Items.Contains(GetItem(number)))
            {
                Money += GetItem(number).Coast;
                Console.WriteLine($"Продан {GetItem(number).ToString()}");
                Items.Remove(GetItem(number));
            }
            else
            {
                Console.WriteLine("Товар не найден.");
            }
        }

        public override void ShowItems()
        {
            Console.WriteLine("Товары для продажи:\n");
            base.ShowItems();
        }

        public Item GetItem(int number)
        {
            int index = number - 1;

            return Items[index];
        }
    }

    class Player : TradeCharacter
    {
        public Player()
        {
            Money = 300f;
            Name = "Игрок";
        }

        public bool BuyItem(Item item)
        {
            if (Money >= item.Coast)
            {
                Money -= item.Coast;
                AddItem(item);
                return true;
            }
            else
            {
                Console.WriteLine("Недостаточно средст.");
                return false;
            }
        }
        public override void ShowItems()
        {
            Console.WriteLine("Ваши вещи:\n");
            base.ShowItems();
        }
    }
}