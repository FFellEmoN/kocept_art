using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];

            int maxRandomValue = 10;
            int requiredNumberIterations = array.Length - 1;
            int temp;

            Random random = new Random();

            Console.WriteLine("Массив до сортировки");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(maxRandomValue);

                Console.Write(array[i] + " ");
            }

            for (int i = 0; i < requiredNumberIterations; i++)
            {
                for (int j = 0; j < requiredNumberIterations - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("\nМассив после сортировки");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
