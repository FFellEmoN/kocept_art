using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float rublesInWallet = 3000;
            float dollarsInWalet = 100;
            float euroInWalet = 200;

            int rubToUsd = 90, usdToRub = 93;
            int rubToEuro = 100, euroToRub = 102;

            float exchangeCurencyCount;

            string firstDesiredCurrency;
            string secondDesiredCurrency;
           // string thirdDesiredCurrency;

            Console.Write("Какие валюты вы хотите конвертировать ?");

            firstDesiredCurrency = Console.ReadLine();
            secondDesiredCurrency = Console.ReadLine();

            switch ()
            {
                case "рубль":
                    
            }
        }
    }
}
