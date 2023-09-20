using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderArrayRepetitionsNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];

            int maxRandomValue = 10;
            int maxSequence = 0;
            int lastStep;
            int counterMaxSequence = 1;
            int mostFrequentRecurringNumber = 0;

            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(maxRandomValue);
            }

            Array.Sort(array);

            for (int i = 1; i < array.Length; i++)
            {
                lastStep = i - 1;

                if (array[i] == array[lastStep])
                {
                    counterMaxSequence++;
                }
                else
                {
                    if (maxSequence < counterMaxSequence)
                    {
                        maxSequence = counterMaxSequence;
                        mostFrequentRecurringNumber = array[lastStep];
                    }

                    counterMaxSequence = 1;
                }

            }

            Console.WriteLine("Массив:");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine($"\n\nЧисло повторяющиеся наибольшое число раз подряд: {mostFrequentRecurringNumber}\n");
            Console.WriteLine($"Сколько раз повторяется число {maxSequence}");
        }
    }
}
