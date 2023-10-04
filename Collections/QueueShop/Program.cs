using System;
using System.Collections.Generic;

namespace QueueShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> buyers = new Queue<int>();

            int checkAmount_1 = 34;
            int checkAmount_2 = 21;
            int checkAmount_3 = 134;
            int checkAmount_4 = 78;
            int shopAccount = 0;
            int lengthQueueBuyers;

            buyers.Enqueue(checkAmount_1);
            buyers.Enqueue(checkAmount_2);
            buyers.Enqueue(checkAmount_3);
            buyers.Enqueue(checkAmount_4);
            lengthQueueBuyers = buyers.Count;

            for (int i = 0; i < lengthQueueBuyers; i++)
            {
                Console.WriteLine($"Чек клиента = {buyers.Peek()}");
                Console.WriteLine("Клиент обслужен!");

                shopAccount += buyers.Dequeue();

                Console.WriteLine($"Денег на счете магазина: {shopAccount}");
                Console.WriteLine("Нажмите любую клавишу для продолжения обслуживания.");
                Console.ReadKey();

                Console.Clear();
            }

            Console.WriteLine("Очередь пуста, вы обслужили всех клиентов!");
        }
    }
}
