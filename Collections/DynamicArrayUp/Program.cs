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
            int sumInputValue;

            string desiredAction;

            bool isInteger;
            bool doExit = true;

            do
            {
                Console.WriteLine($"{SumAllInputValueMenu} - вывести сумму всех веденных чисел ");
                Console.WriteLine($"{ExitProgramMenu} - выйти из программы");

                Console.Write("\nВыбирите команду или введите любое целочисленное значение: ");
                desiredAction = Convert.ToString(Console.ReadLine());

                switch (desiredAction)
                {
                    case SumAllInputValueMenu:
                        sumInputValue = listInputNumber.Sum();

                        Console.WriteLine("Все элементы успешно просуммированы");
                        Console.WriteLine($"Сумма всех элементов = {sumInputValue}");

                        break;

                    case ExitProgramMenu:
                        Console.WriteLine("Досвидания!");

                        doExit = false;
                        break;

                    default:
                        inputValue = Convert.ToInt32(desiredAction);

                        isInteger = inputValue % 1 == 0;

                        if (isInteger)
                        {
                            listInputNumber.Add(inputValue);
                        }
                        else
                        {
                            Console.WriteLine("Не коректный ввод, попробуйти еще раз.");
                        }
                        break;
                }

                if (doExit)
                {
                    Console.WriteLine("Нажмите любую клавишу для того, чтобы продолжить.");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (doExit);
        }
    }
}
