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
            int valueSteap = 7;
            int finishNumber = 96;

            for (int value = 5; value <= finishNumber; value += valueSteap )
            {
                Console.WriteLine(value);
            }
        }
    }
}
