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
            int timeForOnePerson = 10;
            int minInHours = 60;
            int numberOfPeople;
            int hoursInLine;
            int minutesInLine;
            int justMinutes;

            Console.WriteLine("Введите количество человек в очереди.");
            numberOfPeople = Convert.ToInt32(Console.ReadLine());
            justMinutes = numberOfPeople * timeForOnePerson;
            hoursInLine = justMinutes / minInHours;
            minutesInLine = justMinutes % minInHours;
            Console.WriteLine($"Вы должны отстоять в очереди {hoursInLine} часа и {minutesInLine} минут.");
        }
    }
}
