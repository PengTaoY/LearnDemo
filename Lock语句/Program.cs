using System;
using System.Threading;

namespace Lock语句
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[10];

            Account acc = new Account(1000);
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                threads[i] = t;
            }

            for (int i = 0; i < 10; i++)
            {
                threads[i].Start();
            }

            //block main thread until all other threads have ran to completion.
            foreach (var item in threads)
            {
                item.Join();
            }

            Console.ReadKey();
        }
    }
}
