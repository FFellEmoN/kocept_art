using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplanatoryDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            string word;

            dictionary.Add("Летопись",
                "это историческое сочинение, которое представляет собой запись важных событий " +
                "в хронологическом порядке. По структуре и содержанию летописи напоминают " +
                "западноевропейские хроники и анналы");
            dictionary.Add("Телефон",
                "Устройство для передачи и приёма звука на расстоянии");

            Console.Write("Введите слово: ");
            word = Console.ReadLine();

            if (dictionary.ContainsKey(word))
            {
                Console.Write($"\nЗначение: {dictionary[word]}\n");
            } 
            else
            {
                Console.WriteLine("Данное слово отсутствует в толковом словаре.");
            }
        }
    }
}
