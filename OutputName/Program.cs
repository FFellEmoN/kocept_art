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

            char character;

            int additionalCharacters = 3;

            Console.WriteLine("Введите ваше имя.");
            name = Console.ReadLine();
            Console.WriteLine("Введите символ для рамки вокруг имени.");
            character = Convert.ToChar(Console.ReadLine());
            
            for (int i = 0; i <= name.Length + additionalCharacters; i++)
            {
                Console.Write(character);
            }

            Console.WriteLine();
            Console.WriteLine(character + " " + name + " " + character);

            for (int i = 0; i <= name.Length + additionalCharacters; i++)
            {
                Console.Write(character);
            }
        }
    }
}
