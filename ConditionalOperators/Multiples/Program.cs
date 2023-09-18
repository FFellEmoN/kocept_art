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
            int maxThreeDigitNumber = 999;
            int minThreeDigitNumber = 100;
            int value = 0;
            int numberOfMultiples = 0;

            bool isNumberOutOfRange;

            do {
                Console.WriteLine($"Введите число N в диапозоне ({minNumberN} <= N <= {maxNumberN})");
                numberN = Convert.ToInt32(Console.ReadLine());

                isNumberOutOfRange = numberN < minNumberN || numberN > maxNumberN;

                if (isNumberOutOfRange)
                {
                    Console.WriteLine("Вы ввели число в неверном диапозоне, попробуйте еще раз.");
                }
            } while (isNumberOutOfRange);

            for (int i = 0; i <= maxThreeDigitNumber;i += numberN)
            {
                if (i >= minThreeDigitNumber)
                {
                    numberOfMultiples++;
                }
            }

            Console.WriteLine($"Колличество трехзначных чисел кратных {numberN} равно {numberOfMultiples}");
            Console.ReadKey();
        }
    }
}
