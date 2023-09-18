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
            int startValue = 5;
            int steapValue = 7;
            int finisValue = 96;

            for (int i = startValue; i <= finisValue; i += steapValue)
            {
                Console.WriteLine(i);
            }
        }
    }
}
