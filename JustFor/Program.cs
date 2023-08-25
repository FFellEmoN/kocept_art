using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
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
            string massage;

            Console.Write("Введите сообщение: ");
            massage = Console.ReadLine();

            Console.Write("Введите количество повторений: ");
            numberOfCycles = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberOfCycles; i++)
            {
                Console.WriteLine(massage);
            }

            Console.ReadLine();
        }
    }
}
