using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KansasCityShuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[,] twoDimensionalArray = { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 } };

            Console.WriteLine("Массив до перемешивания");
            WriteArray(array);

            Console.WriteLine("\n\nМассив после перемешивания");
            Shuffle(array);
            WriteArray(array);

            Console.WriteLine("\n\nДвумерный массив до перемешивания");
            WriteArray(twoDimensionalArray);

            Console.WriteLine("\nДвумерный массив после перемешивания");
            Shuffle(twoDimensionalArray);
            WriteArray(twoDimensionalArray);



        }

        private static void Shuffle(int[] array)
        {
            int lengthArray = array.Length;

            Random random = new Random();

            for (int i = 0; i < lengthArray; i++)
            {
                swap(array, i, i + random.Next(lengthArray - i));
            }
        }

        private static void Shuffle(int[,] array)
        {
            int leangthLineArray = array.GetLength(0);
            int leangthColomnArray = array.GetLength(1);

            Random random = new Random();

            for (int i = 0; i < leangthLineArray; i++)
            {
                for (int j = 0; j < leangthColomnArray; j++)
                {
                    swap(array, i + random.Next(leangthLineArray - i), j + random.Next(leangthColomnArray - j), i, j);
                }
            }
        }
        private static void swap(int[] array, int aIndex, int bIndex)
        {
            int temp = array[aIndex];
            array[aIndex] = array[bIndex];
            array[bIndex] = temp;

        }

        private static void swap(int[,] array, int changeLine, int changeColomn, int aIndex, int bIndex)
        {
            int temp = array[aIndex, bIndex];
            array[aIndex, bIndex] = array[changeLine, changeColomn];
            array[changeLine, changeColomn] = temp;
        }

        private static void WriteArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        private static void WriteArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
