using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicArrayUp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string SumAllInputValueMenu = "sum";
            const string ExitProgramMenu = "exit";

            List<int> listInputNumber = new List<int>();

            int inputValue;

            string desiredAction;

            bool isInteger;
            bool isWork = true;

            do
            {
                Console.WriteLine($"{SumAllInputValueMenu} - вывести сумму всех веденных чисел ");
                Console.WriteLine($"{ExitProgramMenu} - выйти из программы");

                Console.Write("\nВыбирите команду или введите любое целочисленное значение: ");
                desiredAction = Convert.ToString(Console.ReadLine());

                switch (desiredAction)
                {
                    case SumAllInputValueMenu:
                        SumElemetsList(listInputNumber);
                        break;

                    case ExitProgramMenu:
                        isWork = false;
                        break;

                    default:
                        InputNumberList(listInputNumber, desiredAction);
                        break;
                }

                if (isWork)
                {
                    Console.WriteLine("Нажмите любую клавишу для того, чтобы продолжить.");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (isWork);

            Console.WriteLine("Досвидания!");
        }

        private static void SumElemetsList(List<int> listInputNumber)
        {
            int sumInputValue = listInputNumber.Sum();

            Console.WriteLine("Все элементы успешно просуммированы");
            Console.WriteLine($"Сумма всех элементов = {sumInputValue}");
        }

        private static void InputNumberList(List<int> listInputNumber, string desiredAction)
        {
            int inputValue = Convert.ToInt32(desiredAction);

            //Проверка корректности ввода целого числа
            bool isInteger = inputValue % 1 == 0;

            if (isInteger)
            {
                listInputNumber.Add(inputValue);
            }
            else
            {
                Console.WriteLine("Не коректный ввод, попробуйти еще раз.");
            }
        }
    }
}
