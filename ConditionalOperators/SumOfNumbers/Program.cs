using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            int divider1 = 3;
            int divider2 = 5;
            int sumNumber = 0;
            int minValue = 0;
            int maxValue = 101;

            Random random = new Random();
            number = random.Next(minValue, maxValue);

            for (int i = 0; i <= number; i++)
            {
                if (i % divider1 == 0 || i % divider2 == 0)
                {
                    sumNumber += i;
                }
            }

            Console.WriteLine($"Сумма всех положительных чисел меньше {number} (включая число)" +
                $", которое кратное {divider1} или {divider2} равна {sumNumber}");
        }
    }
}
