using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string controlWorld = "exit";
            string masage;

            Console.Write("Введите проверочное слово: ");
            masage = Console.ReadLine();
            while (masage != controlWorld)
            {
                Console.WriteLine("Введите новое проверочное слово!");
                masage = Console.ReadLine();
            }
            Console.WriteLine("Проверочное слово верное!");
        }
    }
}
