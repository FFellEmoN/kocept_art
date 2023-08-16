using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Album = 52;
            int numberOfPhotos = 3;
            int numberOfRows;
            int remains;

            numberOfRows = Album / numberOfPhotos;
            remains = Album % numberOfPhotos;
            Console.WriteLine($"Количество полностью заполненных рядов: {numberOfRows}");
            Console.WriteLine($"Картинок сверх меры: {remains}");
        }
    }
}
