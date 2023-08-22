using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCycles;
            string masage = "Привет";

            Console.Write("Введите количество повторений: ");
            numberOfCycles = Convert.ToInt32(Console.ReadLine());
           while (numberOfCycles-- > 0)
            {
                Console.WriteLine(masage);
            }
        }
    }
}
