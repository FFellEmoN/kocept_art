using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergingOnceCollecton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = { "1", "2", "1" };
            string[] secondLine = { "2",  "3", "3" };

            List<string> lines = new List<string>();

            lines.AddRange(firstLine);
            lines.AddRange(secondLine);

            Console.WriteLine("Список после добавления в него элементов массива.");
            WriteList(lines);

            lines = lines.Distinct().ToList();

            Console.WriteLine("Список после удаления повторяющихся элементов.");
            WriteList(lines);
        }

        private static void WriteList(List<string> lines)
        {
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
