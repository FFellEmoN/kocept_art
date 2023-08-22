using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int timeForOnePerson = 10;
            const int minInHours = 60;
            int numberOfPeople;
            int hoursInLine;
            int minutesInLine;

            Console.WriteLine("Введите количество человек в очереди.");
            numberOfPeople = Convert.ToInt32(Console.ReadLine());
            minutesInLine = numberOfPeople * timeForOnePerson;
            hoursInLine = minutesInLine / minInHours;
            minutesInLine %= minInHours;
            Console.WriteLine($"Вы должны отстоять в очереди {hoursInLine} часа и {minutesInLine} минут.");
            Console.ReadKey();
        }
    }
}
