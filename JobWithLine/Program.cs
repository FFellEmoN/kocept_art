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
                { 1, 5, 3 }, 
                { 6, 7, 2 } 
            };

            int numberLine = 1;
            int numberColumn = 0;
            int sumLine = 0;
            int productColumn = 0;
        
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");

                    if ( i == numberLine)
                    {
                        sumLine += array[i, j];
                    }

                    if( j == numberColumn)
                    {
                        productColumn += array[i, j];
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Сумма {numberLine + 1} строки: {sumLine}");
            Console.WriteLine($"Произвидение {numberColumn + 1} столбца: {productColumn}");
        }
    }
}
