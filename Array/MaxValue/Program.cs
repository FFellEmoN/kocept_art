using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[10, 10];

            int maxValue = 0;
            int newValue = 0;
            int minRandomValue = 0;
            int maxRandomValue = 10;

            Random random = new Random();

            Console.WriteLine("Исходная матрица\n");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(minRandomValue, maxRandomValue);

                    Console.Write(matrix[i, j] + " ");

                    if (maxValue < matrix[i, j])
                    {
                        maxValue = matrix[i, j];
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nНовая матрица\n");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (maxValue == matrix[i, j])
                    {
                        matrix[i, j] = newValue;
                    }
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\n\nМаксимальное число: {maxValue}");
        }
    }
}
