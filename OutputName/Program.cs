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

            for (int i = 0; i < name.Length; i++)
            {
                characterString += character;
            }

            middleLine = character + name + character;

            Console.WriteLine(characterString);
            Console.WriteLine(middleLine);
            Console.WriteLine(characterString);
        }
    }
}
