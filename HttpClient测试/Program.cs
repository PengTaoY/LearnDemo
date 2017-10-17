using System;
using System.Net.Http;

namespace HttpClient测试
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting connnections:");
            for (int i = 0; i < 10; i++)
            {
                using (var client = new HttpClient())
                {
                    var result = client.GetAsync("http://www.baidu.com");
                    Console.WriteLine(result.Status);
                }
            }


            Console.WriteLine("Connections done.");

            Console.ReadKey();
        }
    }
}
