using System;
using System.Collections.Generic;

namespace Shoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            Saller saller = new Saller();

            Shoop shoop = new Shoop(saller, player);

            shoop.Work();
        }
    }

    class Shoop
    {
        private Player _player;
        private Saller _saller;

        public Shoop(Saller saller, Player player)
        {
            _saller = saller;
            _player = player;
            _saller.AddItem(new Item("меч", 15));
            _saller.AddItem(new Item("топор", 20));
        }

        public void Work()
        {
            const string TradeShoopMenu = "1";
            const string ShowItemsPlayrMenu = "2";
            const string ShowSallerMoneyMenu = "3";
            const string ShowPlayerMoneyMenu = "4";
            const string ExitMenu = "5";

            string diciredAction;

            bool isRunning = true;

            do
            {
                Console.WriteLine($"{TradeShoopMenu}) - открыть магазин.");
                Console.WriteLine($"{ShowItemsPlayrMenu}) - показать предметы игрока.");
                Console.WriteLine($"{ShowSallerMoneyMenu}) - показать деньги {_saller.Name}.");
                Console.WriteLine($"{ShowPlayerMoneyMenu}) - показать деньги {_player.Name}.");
                Console.WriteLine($"{ExitMenu}) - выйти.");

                Console.Write("\nВведите желаемое действие: ");
                diciredAction = Console.ReadLine();
                Console.WriteLine();

                switch (diciredAction)
                {
                    case TradeShoopMenu:
                        Trade();
                        break;

                    case ShowItemsPlayrMenu:
                        _player.ShowItems();
                        break;

                    case ShowSallerMoneyMenu:
                        _saller.ShowMoney();
                        break;

                    case ShowPlayerMoneyMenu:
                        _player.ShowMoney();
                        break;

                    case ExitMenu:
                        isRunning = false;
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();
                Console.Clear();
            } while (isRunning);
        }

        private void Trade()
        {
            string disiredItem;
            Item item;

            _saller.ShowMoney();
            _player.ShowMoney();
            Console.WriteLine("\nКакой товар вы хотите приобрести ?\n");
            _saller.ShowItems();

            Console.Write("\nВведите номер товара: ");
            disiredItem = Console.ReadLine();

            if (int.TryParse(disiredItem, out int number) &&
                number > 0 &&
                number <= _saller.CountItems)
            {
                item = _saller.GetItem(number);

                if (_player.IsEnoughMoney(item.Coast))
                {
                    _saller.TrySellItem(item);
                    _player.BuyItem(item);
                }
                else
                {
                    Console.WriteLine("Недостаточно средст.");
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
       
        public int CountItems
        {
            get { return Items.Count; }
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

        public Item GetItem(int number)
        {
            int index = number - 1;

            return Items[index];
        }

        public void TrySellItem(Item item)
        {
            if (Items.Contains(item))
            {
                Console.WriteLine($"Продан {item.ToString()}");
                SellItem(item);
            }
            else
            {
                Console.WriteLine("Товар не найден.");
            }
        }

        private void SellItem(Item item)
        {
                Money += item.Coast;
                Items.Remove(item);
        }

        public override void ShowItems()
        {
            Console.WriteLine("Товары для продажи:\n");
            base.ShowItems();
        }
    }

    class Player : TradeCharacter
    {
        public Player()
        {
            Money = 300f;
            Name = "Игрок";
        }

        public bool IsEnoughMoney(float coast)
        {
            return Money >= coast;
        }

        public void BuyItem(Item item)
        {
            Money -= item.Coast;
            AddItem(item);
        }

        public override void ShowItems()
        {
            Console.WriteLine("Ваши вещи:\n");
            base.ShowItems();
        }
    }
}