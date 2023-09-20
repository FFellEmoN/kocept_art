using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Это пример текста, который нужно разделить на слова.";

            string[] words = text.Split(' ');

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
