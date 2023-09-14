using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int conditionNumber;
            int number = 2;
            int startDegree = 1;
            int degree = startDegree;
            int result = 1;

            Random random = new Random();
            conditionNumber = random.Next(11);

            Console.WriteLine($"Случайное число: {conditionNumber}");

            if (conditionNumber >= number)
            {
                do
                {
                    for (int i = 0; i < degree; i++)
                    {
                        result *= number;
                    }

                    if (conditionNumber >= result)
                    {
                        result = 1;
                        degree++;
                    }
                } while (conditionNumber >= result);
            }

            Console.WriteLine($"Степень: {degree}");
            Console.WriteLine($"{number} в степени {degree} = {result}");
        }
    }
}