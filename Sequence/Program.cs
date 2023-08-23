using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int value = 5;
            int valueSteap = 7;
            int steaps = 14;

            for (int i = 0; i < steaps ; i++)
            {
                Console.WriteLine(value);
                value += valueSteap;
            }
        }
    }
}
