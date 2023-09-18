using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string middleLine;
            string characterString = "";

            char character;

            Console.WriteLine("Введите ваше имя.");
            name = Console.ReadLine();
            Console.WriteLine("Введите символ для рамки вокруг имени.");
            character = Console.ReadKey(true).KeyChar;

            middleLine = character + name + character;

            for (int i = 0; i < middleLine.Length; i++)
            {
                characterString += character;
            }

            Console.WriteLine(characterString);
            Console.WriteLine(middleLine);
            Console.WriteLine(characterString);
        }
    }
}
