using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 5;
            int secondValue = 7;
            int value;

            Console.WriteLine("До замены");
            Console.WriteLine($"Первое: {number}, Второе: {secondValue}");

            value = number;
            number = secondValue;
            secondValue = value;

            Console.WriteLine("После замены");
            Console.WriteLine($"Первое: {number}, Второе: {secondValue}");
        }
    }
}
