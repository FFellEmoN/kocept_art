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
            const string ConvertRubleToDollarMenu = "1";
            const string ConvertRubleToEuroMenu = "2";
            const string ConvertDollarToRubleMenu = "3";
            const string ConvertDollarToEuroMenu = "4";
            const string ConvertEuroToRubleMenu = "5";
            const string ConvertEuroToDollarMenu = "6";

            float rublesInWallet = 3000;
            float dollarsInWalet = 100;
            float euroInWalet = 200;
            float rubleToDollar = 0.010449f;
            float dollarToRuble = 95.71f;
            float rubleToEuro = 0.009664f;
            float euroToRuble = 103.48f;
            float dollarToEuro = 0.92f;
            float euroToDollar = 1.08f;
            float exchangeCurrencyCount;

            string desiredOperatoion;

            int answerForExit;
            int answerNo = 0;
            int answerYes = 1;

            do
            {
                Console.WriteLine("Выберите необоходимую операцию.");
                Console.WriteLine($"{ConvertRubleToDollarMenu} - обменять рубль на доллары"); ;
                Console.WriteLine($"{ConvertRubleToEuroMenu} - обменять рубль на евро");
                Console.WriteLine($"{ConvertDollarToRubleMenu} - обменять доллар на рубль");
                Console.WriteLine($"{ConvertDollarToEuroMenu} - обменять доллар на евро");
                Console.WriteLine($"{ConvertEuroToRubleMenu} - обменять евро на рубль");
                Console.WriteLine($"{ConvertEuroToDollarMenu} - обменять евро на доллар");

                Console.Write("Выш выбор: ");
                desiredOperatoion = Console.ReadLine();

                switch (desiredOperatoion)
                {
                    case ConvertRubleToDollarMenu:
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

                    case ConvertRubleToEuroMenu:
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

                    case ConvertDollarToRubleMenu:
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

                    case ConvertDollarToEuroMenu:
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

                    case ConvertEuroToRubleMenu:
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

                    case ConvertEuroToDollarMenu:
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

                Console.WriteLine($"{answerNo} - НЕТ, {answerYes} - ДА");
                answerForExit = Convert.ToInt32(Console.ReadLine());
            } while (answerForExit < answerYes);

            Console.WriteLine("Всего доброго!");
        }
    }
}
