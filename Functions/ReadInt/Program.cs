using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string lineNumber;
            int number;
            bool isSucces;

            Console.Write("Введите число: ");
            lineNumber = Console.ReadLine();

            isSucces = int.TryParse(lineNumber, out number);

            if (isSucces)
            {
                Console.WriteLine($"Представленое число в эквивалентное ему 32-битовое целое число со знаком: {number}.");
            }
            else
            {
                Console.WriteLine($"Конвертация числа {lineNumber} не выполненна.");
            }
        }
    }
}
