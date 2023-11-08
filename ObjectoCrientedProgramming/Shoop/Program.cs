using System;
using System.Collections.Generic;

namespace Shoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = 20;
            int health = 100;
            string disiredItem;

            Player player = new Player(armor, health);

            Seller seller = new Seller();

            Item purchased;

            Console.WriteLine($"Здоровье игрока до покупки: {player.Health}");
            Console.WriteLine($"Броня игрока до покупки: {player.Armor}");
            Console.WriteLine("Торговец, покажи свои товары.\n");
            seller.Show();
            Console.WriteLine($"У вас денег: {player.Money}");

            Console.Write("\nХочу купить предмет под номером: ");
            disiredItem = Console.ReadLine();

            if (int.TryParse(disiredItem, out int index) && index <= seller.Items.Count && index > 0) {
                purchased = seller.Items[index - 1];

                if (player.Buy(purchased.Cost))
                {
                    player.AddItem(purchased);
                    
                }
            }
            else
            {
                Console.WriteLine("Вы ввели неверное число.");
            }

            Console.WriteLine($"\nУ вас осталось денег: {player.Money}\n");
            player.ShowItems();
            Console.WriteLine($"\nЗдоровье игрока после покупки: {player.Health}");
            Console.WriteLine($"Броня игрока после покупки: {player.Armor}");
        }

        class Player
        {
            public Player(int armor, int health)
            {
                Items = new List<Item>();
                Armor = armor;
                Health = health;
                Money = 300;
            }

            public List<Item> Items { get; private set; }

            public int Armor { get; private set; }
            public int Health { get; private set; }
            public int Money { get; private set; }

            public bool Buy(int amount)
            {
                if (Money >= amount)
                {
                    Money -= amount;
                    return true;
                }
                else
                {
                    Console.WriteLine("У вас недостаточно денег.");
                    return false;
                }
            }

            public void AddItem(Item item)
            {
                Items.Add(item);
                ApplyingEffectItem(item);
            }

            public void ShowItems()
            {
                Console.WriteLine("Список всех предметов игрока: ");

                foreach (Item item in Items)
                {
                    Console.WriteLine($"{item.Name}");
                }
            }

            public void SetArmor(int armor)
            {
                Armor += armor;
            }

            public void SetHealth(int health)
            {
                Health += health;
            }

            private void ApplyingEffectItem(Item item)
            {
                switch (item)
                {
                    case Axe axe:
                        axe.EffectCurse(this);
                        break;

                    case Sword sword:
                        sword.EffectStrengthening(this);
                        break;

                    default:
                        Console.WriteLine("Такого предмата не существует.");
                        break;
                }
            }
        }

        class Seller
        {
            public Seller()
            {
                Items = new List<Item>();
                FillItems();
            }

            public List<Item> Items { get; private set; }
            private void FillItems()
            {
                Random random = new Random();

                int numberItems = random.Next(1, 3);
                int maxCost = 50;
                int minCost = 10;

                for (int i = 0; i < numberItems; i++)
                {
                    Items.Add(new Axe(random.Next(minCost, maxCost)));
                    Items.Add(new Sword(random.Next(minCost, maxCost)));
                }
            }

            public void Show()
            {
                int i = 1;

                Console.WriteLine("Список предметов торговца: ");
                foreach (Item item in Items)
                {
                    Console.WriteLine($"{i++}){item.Name} - цена {item.Cost} серебра");
                    Console.WriteLine($"{item.Description}\n");
                }
            }
        }

        class Item
        {
            public Item(string name, string description, int price)
            {
                Name = name;
                Description = description;
                Cost = price;
            }

            public string Name { get; private set; }
            public string Description { get; private set; }

            public int Cost { get; private set; }
        }

        class Axe : Item
        {
            private static string _name = "Проклятый топор";
            private static string _description = "Проклятый давным давно, ржавый топор.\n" +
                "Его владелец теряет часть своих жизненных сил.";

            public Axe(int price) : base(_name, _description, price)
            {
                DecreaseHealth = -20;
            }

            public int DecreaseHealth { get; private set; }

            public void EffectCurse(Player player)
            {
                player.SetHealth(DecreaseHealth);

                Console.WriteLine("Игрок проклят, здоровье уменьшено.");
            }
        }

        class Sword : Item
        {
            private static string _name = "Меч для самообороны";
            private static string _description = "Отличный меч для начинающих героев.\nДает бонус к защите.";

            public Sword(int price) : base(_name, _description, price)
            {
                BustArmor = 5;
            }

            public int BustArmor { get; private set; }

            public void EffectStrengthening(Player player)
            {
                player.SetArmor(BustArmor);

                Console.WriteLine("Игрок получает бонус к защите.");
            }
        }
    }
}
