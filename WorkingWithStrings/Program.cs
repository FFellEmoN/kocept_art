using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string nationality;
            string profession;
            string zodiacSign;
            int age;

            Console.WriteLine("Введите ваше имя ?");
            name = Console.ReadLine();

            Console.WriteLine("Введите ваш возраст ?");
            age = Convert.ToInt32( Console.ReadLine() );

            Console.WriteLine("Введите вашу национальность ?");
            nationality = Console.ReadLine();

            Console.WriteLine("Введите вашу профессию ?");
            profession = Console.ReadLine();

            Console.WriteLine("Какой у вас знак задиака ?");
            zodiacSign = Console.ReadLine();

            Console.WriteLine($"Ваше имя {name}, " +
                $"ваш возраст {age}, " +
                $"ваша национальность {nationality}, " +
                $"ваша профессия {profession}," +
                $"ваш знак зодиака {zodiacSign}.");
        }
    }
}
