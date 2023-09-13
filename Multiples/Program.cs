using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberN;
            int maxNumberN = 27;
            int minNumberN = 1;
            int valueMax = 999;
            int valueMin = 100;
            int value;
            int numberOfMultiples = 0;

            do {
                Console.WriteLine($"Введите число N в диапозоне ({minNumberN} <= N <= {maxNumberN})");
                numberN = Convert.ToInt32(Console.ReadLine());

                if (numberN >= minNumberN && numberN <= maxNumberN)
                {
                    value = numberN;
                    break;
                }
                else
                {
                    Console.WriteLine("Вы ввели число в неверном диапозоне, попробуйте еще раз.");
                }
            } while (true);

            while (value <= valueMax)
            {
                value += numberN;
                if (value >= valueMin) numberOfMultiples++;
            }

            Console.WriteLine($"Колличество трехзначных чисел кратных {numberN} равно {numberOfMultiples}");
        }
    }
}
