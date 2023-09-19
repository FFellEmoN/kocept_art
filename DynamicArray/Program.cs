using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string SumAllInputValueMenu = "1";
            const string InputValueMenu = "2";
            const string ExitProgramMenu = "3";

            int[] array = new int[1];
            int[] newArray;

            int inputValue;
            int sumInputValue = 0;

            string desiredAction;
            do
            {
                Console.WriteLine($"{SumAllInputValueMenu} - проссумировать все введеные числа");
                Console.WriteLine($"{InputValueMenu} - ввести число");
                Console.WriteLine($"{ExitProgramMenu} - выйти из программы");

                Console.Write("\nВыбирите команду: ");
                desiredAction = Convert.ToString(Console.ReadLine());

                switch (desiredAction)
                {
                    case SumAllInputValueMenu:
                        for (int i = 0; i < array.Length; i++)
                        {
                            sumInputValue += array[i];
                        }

                        Console.WriteLine("Все элементы успешно просуммированы");
                        Console.WriteLine($"Сумма всех элементов = {sumInputValue}");
                        break;

                        case InputValueMenu:

                }
            } while (desiredAction == $"{ExitProgramMenu}");
        }
    }
}
