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
            const string NumberOfOperationMenu_1 = "1";
            const string NumberOfOperationMenu_2 = "2";
            const string NumberOfOperationMenu_3 = "3";
            const string NumberOfOperationMenu_4 = "4";
            const string NumberOfOperationMenu_5 = "5";
            const string NumberOfOperationMenu_6 = "6";
            
            float rublesInWallet = 3000;
            float dollarsInWalet = 100;
            float euroInWalet = 200;

            float rubleToDollar = 0.010449f, dollarToRuble = 95.71f;
            float rubleToEuro = 0.009664f, euroToRuble = 103.48f;
            float dollarToEuro = 0.92f, euroToDollar = 1.08f;

            float exchangeCurrencyCount;

            string desiredOperatoion;

            int answerForExit;

            do {
                Console.WriteLine("Выберите необоходимую операцию.");
                Console.WriteLine("1 - обменять рубль на доллары");
                Console.WriteLine("2 - обменять рубль на евро");
                Console.WriteLine("3 - обменять доллар на рубль");
                Console.WriteLine("4 - обменять доллар на евро");
                Console.WriteLine("5 - обменять евро на рубль");
                Console.WriteLine("6 - обменять евро на доллар");
                Console.Write("Выш выбор: ");
                desiredOperatoion = Console.ReadLine();

                switch (desiredOperatoion)
                {
                    case NumberOfOperationMenu_1:
                        Console.WriteLine("Обмен рублей на доллар.");
                        Console.WriteLine("Сколько вы хотите обменять ?");
                        exchangeCurrencyCount = Convert.ToInt32(Console.ReadLine());
                        if (rublesInWallet >= exchangeCurrencyCount)
                        {
                            rublesInWallet -= exchangeCurrencyCount;
                            dollarsInWalet += exchangeCurrencyCount * rubleToDollar;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое количество рублей.");
                        }
                        break;
                    case NumberOfOperationMenu_2:
                        Console.WriteLine("Обмен рублей на евро.");
                        Console.WriteLine("Сколько вы хотите обменять ?");
                        exchangeCurrencyCount = Convert.ToInt32(Console.ReadLine());
                        if (rublesInWallet >= exchangeCurrencyCount)
                        {
                            rublesInWallet -= exchangeCurrencyCount;
                            euroInWalet += exchangeCurrencyCount * rubleToEuro;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое количество рублей.");
                        }
                        break;
                    case NumberOfOperationMenu_3:
                        Console.WriteLine("Обмен долларов на рубль.");
                        Console.WriteLine("Сколько вы хотите обменять ?");
                        exchangeCurrencyCount = Convert.ToInt32(Console.ReadLine());
                        if (dollarsInWalet >= exchangeCurrencyCount)
                        {
                            dollarsInWalet -= exchangeCurrencyCount;
                            rublesInWallet += exchangeCurrencyCount * dollarToRuble;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое количество долларов.");
                        }
                        break;
                    case NumberOfOperationMenu_4:
                        Console.WriteLine("Обмен долларов на евро.");
                        Console.WriteLine("Сколько вы хотите обменять ?");
                        exchangeCurrencyCount = Convert.ToInt32(Console.ReadLine());
                        if (dollarsInWalet >= exchangeCurrencyCount)
                        {
                            dollarsInWalet -= exchangeCurrencyCount;
                            euroInWalet += exchangeCurrencyCount * dollarToEuro;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое количество долларов.");
                        }
                        break;
                    case NumberOfOperationMenu_5:
                        Console.WriteLine("Обмен евро на рубли.");
                        Console.WriteLine("Сколько вы хотите обменять ?");
                        exchangeCurrencyCount = Convert.ToInt32(Console.ReadLine());
                        if (euroInWalet >= exchangeCurrencyCount)
                        {
                            euroInWalet -= exchangeCurrencyCount;
                            rublesInWallet += exchangeCurrencyCount * euroToRuble;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое количество eвро.");
                        }
                        break;
                    case NumberOfOperationMenu_6:
                        Console.WriteLine("Обмен евро на доллары.");
                        Console.WriteLine("Сколько вы хотите обменять ?");
                        exchangeCurrencyCount = Convert.ToInt32(Console.ReadLine());
                        if (euroInWalet >= exchangeCurrencyCount)
                        {
                            euroInWalet -= exchangeCurrencyCount;
                            dollarsInWalet += exchangeCurrencyCount * euroToDollar;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое количество евро.");
                        }
                        break;
                    default:
                        Console.WriteLine("Введеной операции не существует, пожалуйств введите номер операции снова");
                        break;
                }
            
                Console.WriteLine($"Ваш баланс: {rublesInWallet} рублей;");
                Console.WriteLine($"            {dollarsInWalet} долларов;");
                Console.WriteLine($"            {euroInWalet} евро.");
                Console.WriteLine();

                Console.WriteLine("Закончить операцию ?");
                Console.WriteLine("0 - НЕТ, 1 - ДА");
                answerForExit = Convert.ToInt32(Console.ReadLine());
            } while (answerForExit < 1);

            Console.WriteLine("Всего доброго!");
        }
    }
}
