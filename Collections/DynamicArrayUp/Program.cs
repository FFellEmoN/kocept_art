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

            string desiredAction;

            bool isWork = true;

            do
            {
                Console.WriteLine($"{SumAllInputValueMenu} - вывести сумму всех веденных чисел ");
                Console.WriteLine($"{ExitProgramMenu} - выйти из программы");

                Console.Write("\nВыбирите команду или введите любое целочисленное значение: ");
                desiredAction = Console.ReadLine();

                switch (desiredAction)
                {
                    case SumAllInputValueMenu:
                        SumElemetsList(listInputNumber);
                        break;

                    case ExitProgramMenu:
                        isWork = false;
                        break;

                    default:
                        AddNumber(listInputNumber, desiredAction);
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

        private static void AddNumber(List<int> listInputNumber, string desiredAction)
        {
            if (int.TryParse(desiredAction, out int inputValue))
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
