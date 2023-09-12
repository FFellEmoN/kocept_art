using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordProtectedProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfAttemptsBeforeBlocking = 3;
            int numberOfFailAttempts = 0;

            string secretMassage = "Ура, пароль верный!";
            string password = "qwerty";
            string checkPassword;

            do
            {
                Console.Write("Введите пароль: ");
                checkPassword = Console.ReadLine();

                if (password == checkPassword)
                {
                    Console.WriteLine(secretMassage);
                    break;
                }

                if(numberOfAttemptsBeforeBlocking != 0)
                {
                    numberOfFailAttempts++;
                    Console.WriteLine("Пароль не верный, повторите попытку.");
                    Console.WriteLine($"Осталось попыток: {numberOfAttemptsBeforeBlocking - numberOfFailAttempts}");
                }

                if(numberOfFailAttempts ==  numberOfAttemptsBeforeBlocking)
                {
                    Console.WriteLine("Заблокированно!");
                    break;
                }
            } while (password != checkPassword);
        }
    }
}
