using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string SumAllInputValueMenu = "sum";
            const string ExitProgramMenu = "exit";

            int[] array = new int[0];
            int[] newArray;

            int inputValue;
            int sumInputValue = 0;
            int magnificationValu;
            int lastIndexArray;

            string desiredAction;

            bool isInteger;

            do
            {
                Console.WriteLine($"{SumAllInputValueMenu} - вывести сумму всех веденных чисел ");
                Console.WriteLine($"{ExitProgramMenu} - выйти из программы");

                Console.Write("\nВыбирите команду или введите любое целочисленное значение: ");
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

                        sumInputValue = 0;
                        break;

                    case ExitProgramMenu:
                        Console.WriteLine("Досвидания!");
                        break;
                    default:               
                        inputValue = Convert.ToInt32(desiredAction);

                        isInteger = inputValue % 1 == 0;

                        if (isInteger)
                        {
                            magnificationValu = array.Length + 1;
                            newArray = new int[magnificationValu];

                            for (int i = 0; i < array.Length; i++)
                            {
                                newArray[i] = array[i];
                            }

                            array = newArray;
                            lastIndexArray = array.Length - 1;
                            array[lastIndexArray] = inputValue;
                        }
                        else
                        {
                            Console.WriteLine("Не коректный ввод, попробуйти еще раз.");
                        }
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу для того, чтобы продолжить.");
                Console.ReadLine();
                Console.Clear();
            } while (desiredAction != $"{ExitProgramMenu}");
        }
    }
}
