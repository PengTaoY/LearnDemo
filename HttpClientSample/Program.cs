using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientSample
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            //client.BaseAddress = new Uri("http://www.baidu.com");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            GetStringAsync("htttp://www.baidu.com");

            Console.ReadLine();
        }

        static async Task<Product> GetProductAsync(string path)
        {
            Product product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;
        }

        static async Task<string> GetStringAsync(string path)
        {
            string result = string.Empty;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var aa = response.Content.Headers;
                var bb = response.Headers;
                var cc = await response.Content.ReadAsAsync<string>();
            }
            return result;
        }
    }


}
