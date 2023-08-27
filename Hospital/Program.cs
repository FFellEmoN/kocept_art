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
            int minutesInHour = 60;
            int numberOfPeople;
            int hoursInLine;
            int minutesInLine;
            int totalWaitingTimeInMinutes;

            Console.Write("Введите количество человек в очереди: ");
            numberOfPeople = Convert.ToInt32(Console.ReadLine());
            totalWaitingTimeInMinutes = numberOfPeople * timeForOnePerson;
            hoursInLine = totalWaitingTimeInMinutes / minutesInHour;
            minutesInLine = totalWaitingTimeInMinutes % minutesInHour;
            Console.WriteLine($"Вы должны отстоять в очереди {hoursInLine} часа и {minutesInLine} минут.");
        }
    }
}
