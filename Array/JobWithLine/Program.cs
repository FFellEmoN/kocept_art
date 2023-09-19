using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobWithLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array = {
                { 2, 5, 3 },
                { 6, 7, 2 }
            };

            int firstIndexArray = array[0, 0];
            int numberLine = 1;
            int numberColumn = 0;
            int sumLine = 0;
            int productColumn = firstIndexArray;
            int realyNumberLine = numberLine + 1;
            int realyNumberColumn = numberColumn + 1;

            Console.WriteLine("Массив:");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++) 
                {
                    if (i == numberLine)
                    {
                        sumLine += array[i, j];
                    }
                }
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j == numberColumn && array[i, j] != firstIndexArray)
                    {
                        productColumn *= array[i, j];
                    }
                }
            }

            Console.WriteLine($"Сумма {realyNumberLine} строки: {sumLine}");
            Console.WriteLine($"Произвидение {realyNumberColumn} столбца: {productColumn}");
        }
    }
}
