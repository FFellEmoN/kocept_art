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
            int numberOfAttemps;

            string secretMassage = "Ура, пароль верный!";
            string password = "qwerty";
            string passwordVerified;

            do
            {
                Console.Write("Введите пароль: ");
                passwordVerified = Console.ReadLine();

                if (password == passwordVerified)
                {
                    Console.WriteLine(secretMassage);
                }

                if (numberOfAttemptsBeforeBlocking != 0)
                {
                    numberOfFailAttempts++;
                    Console.WriteLine("Пароль не верный, повторите попытку.");
                    numberOfAttemps = numberOfAttemptsBeforeBlocking - numberOfFailAttempts;
                    Console.WriteLine($"Осталось попыток: {numberOfAttemps}");
                }

                if (numberOfFailAttempts == numberOfAttemptsBeforeBlocking)
                {
                    Console.WriteLine("Заблокированно!");
                }
            } while (password != passwordVerified || numberOfFailAttempts != numberOfAttemptsBeforeBlocking);
        }
    }
}
