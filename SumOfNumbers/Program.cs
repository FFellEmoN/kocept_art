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
            int firstMultipleNumber = 3;
            int secondMultipleNumber = 5;
            int sumNumber = 0;

            Random random = new Random();
            number = random.Next(0, 101);

            for (int i = 0; i <= number; i++)
            {
                if (i % firstMultipleNumber == 0 || i % secondMultipleNumber == 0)
                {
                    sumNumber += i;
                }
            }

            Console.WriteLine($"Сумма всех положительных чисел меньше {number} (включая число)" +
                $", которое кратное 3 или 5 равна {sumNumber}");
        }
    }
}
