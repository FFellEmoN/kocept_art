using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopCrystals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gold;
            int crystals = 123;
            int characterCrystals = 0;
            int crystalCost = 10;
            int desiredNumberOfCrystals;

            Console.WriteLine("Введите количества золота.");
            gold = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"В магазине имеется {crystals} шт кристалов. " +
                $"Цена 1 шт = {crystalCost}. " +
                $"Сколько кристаллов вы хотите купить?");
            desiredNumberOfCrystals = Convert.ToInt32(Console.ReadLine());
            gold -= desiredNumberOfCrystals * crystalCost;
            characterCrystals += desiredNumberOfCrystals;

            Console.WriteLine($"У вас кристалов: {characterCrystals}");
            Console.WriteLine($"У вас золота: {gold}");
        }
    }
}
