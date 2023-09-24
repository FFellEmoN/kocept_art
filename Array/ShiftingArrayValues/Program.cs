using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftingArrayValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5 };

            int firstArrayValue = 0;
            int numberShifts;
            int firstIndexArray = 0;
            int nextIndexArray = 1;
            int lastIndexArray = array.Length - 1;
            int requiredNymberIterarions = array.Length - 1;

            Console.WriteLine("Массив до смещения");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.Write("\nВведите количество сдвигов: ");
            numberShifts = Convert.ToInt32(Console.ReadLine());

            if (numberShifts >= array.Length)
                numberShifts %= array.Length;

            for (int i = 0; i < numberShifts; i++)
            {
                firstArrayValue = array[firstIndexArray];

                for (int j = 0; j < requiredNymberIterarions; j++)
                {
                    array[j] = array[j + nextIndexArray];
                }

                array[lastIndexArray] = firstArrayValue;
            }

            Console.WriteLine("Массив после смещения");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
