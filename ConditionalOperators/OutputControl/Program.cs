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
            string massage;

            do
            {
                Console.Write("Введите проверочное слово: ");
                massage = Console.ReadLine();
            } while (massage != controlWorld);

                Console.WriteLine("Проверочное слово верное!");
        }
    }
}
