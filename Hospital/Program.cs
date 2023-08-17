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
            int numberOfPeople;
            int hours;
            int minutes;
            const int timeForOnePerson = 10;
            const int minInHours = 60;
            

            Console.WriteLine("Введите количество человек в очереди.");
            numberOfPeople = Convert.ToInt32(Console.ReadLine());
            minutes = numberOfPeople * timeForOnePerson;
            hours = minutes / minInHours;
            minutes %= minInHours;

            Console.WriteLine($"Вы должны отстоять в очереди {hours} часа и {minutes} минут.");
            Console.ReadKey();
        }
    }
}
