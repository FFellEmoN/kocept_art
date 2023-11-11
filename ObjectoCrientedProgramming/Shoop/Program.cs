using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;

namespace Shoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Saller saller = new Saller();

            string disiredItem;

            saller.AddItem(new Item("меч", 15));
            saller.AddItem(new Item("топор", 20));

            Console.WriteLine("Деньги игрока: " + player.Money);
            Console.WriteLine("Деньги торговца: " + saller.Money);
            Console.WriteLine();
            Console.WriteLine("Какой товар вы хотите приобрести.");
            saller.ShowItems();

            Console.Write("\nВведите номер товара:");
            disiredItem = Console.ReadLine();

            if (int.TryParse(disiredItem, out int number) &&
                number > 0 &&
                number <= saller.GetCountItems())
            {
                saller.SellItem(player, number);
            }
            else
            {
                Console.WriteLine("Вы ввели не число или некоректное число.");
            }

            Console.WriteLine("Деньги игрока: " + player.Money);
            Console.WriteLine("Деньги торговца: " + saller.Money);
            Console.WriteLine();
            player.ShowItems();
        }
    }

    class Item
    {
        public string Name { get; private set; }
        public float Coast { get; private set; }

        public Item(string name, float coast)
        {
            Name = name;
            Coast = coast;
        }

        public override string ToString()
        {
            return $"Товар: {Name}, Цена: {Coast}";
        }
    }

    class TradeCharacter
    {
        protected List<Item> _items;

        protected TradeCharacter()
        {
            _items = new List<Item>();
        }

        public float Money { get; protected set; }

        public int GetCountItems()
        {
            return _items.Count;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public virtual void ShowItems()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_items[i].ToString()}");
            }
        }
    }

    class Saller : TradeCharacter
    {
        public Saller()
        {
            Money = 300f;
        }
        public void SellItem(Player player, int number)
        {
            int index = number - 1;

            if (_items.Contains(_items[index]) && player.BuyItem(_items[index]))
            {
                Money += _items[index].Coast;
                Console.WriteLine($"Продан {_items[index].ToString()}");
                _items.Remove(_items[index]);
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
    }

    class Player : TradeCharacter
    {
        public Player()
        {
            Money = 300f;
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