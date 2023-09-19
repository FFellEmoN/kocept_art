using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LocalMax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];

            int maxRandomValue = 10;
            int firstLocalNumber = 0;
            int lastLocalNumber = array.Length - 1;
            int nextStep = 1;
            int lastStep = -1;

            Random random = new Random();

            Console.WriteLine($"Массив из {array.Length} элементов");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(maxRandomValue);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("\nВсе локальные максимумы");

            if (array[firstLocalNumber] > array[firstLocalNumber + nextStep])
            {
                Console.Write(array[firstLocalNumber] + " ");
            }

            if (array[lastLocalNumber] > array[lastLocalNumber + lastStep])
            {
                Console.Write(array[lastLocalNumber] + " ");
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (i != firstLocalNumber && i != lastLocalNumber &&
                    array[i] > array[i + nextStep] && array[i] > array[i + lastStep])
                {
                    Console.Write(array[i] + " ");
                }
            }
        }
    }
}
