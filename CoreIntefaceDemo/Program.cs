using System;

namespace CoreIntefaceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ITest test;
            Test t = new Test();
            test = t;
            var equatable = test.queryString(4);
            

            foreach (var item in equatable)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();

            Test2 test2 = new Test2();
            test = test2;
            foreach (var item in test2.queryString(4))
            {
                Console.WriteLine(item);
                Console.WriteLine(test2.T());
            }

            Console.ReadKey();

            Console.WriteLine("Hello World!");
        }
    }
}
