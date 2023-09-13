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
            const string ConvertRubleToDollar = "1";
            const string ConvertRubleToEuro = "2";
            const string ConvertDollarToRuble = "3";
            const string ConvertDollarToEuro = "4";
            const string ConvertEuroToRuble = "5";
            const string ConvertEuroToDollar = "6";

            float rublesInWallet = 3000;
            float dollarsInWalet = 100;
            float euroInWalet = 200;
            float rubleToDollar = 0.010449f, dollarToRuble = 95.71f;
            float rubleToEuro = 0.009664f, euroToRuble = 103.48f;
            float dollarToEuro = 0.92f, euroToDollar = 1.08f;
            float exchangeCurrencyCount;

            string desiredOperatoion;

            int answerForExit;
            int answerNo = 0;
            int answerYes = 1;

            do
            {
                Console.WriteLine("Выберите необоходимую операцию.");
                Console.WriteLine($"{ConvertRubleToDollar} - обменять рубль на доллары"); ;
                Console.WriteLine($"{ConvertRubleToEuro} - обменять рубль на евро");
                Console.WriteLine($"{ConvertDollarToRuble} - обменять доллар на рубль");
                Console.WriteLine($"{ConvertDollarToEuro} - обменять доллар на евро");
                Console.WriteLine($"{ConvertEuroToRuble} - обменять евро на рубль");
                Console.WriteLine($"{ConvertEuroToDollar} - обменять евро на доллар");

                Console.Write("Выш выбор: ");
                desiredOperatoion = Console.ReadLine();

                switch (desiredOperatoion)
                {
                    case ConvertRubleToDollar:
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

                    case ConvertRubleToEuro:
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

                    case ConvertDollarToRuble:
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

                    case ConvertDollarToEuro:
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

                    case ConvertEuroToRuble:
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

                    case ConvertEuroToDollar:
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
