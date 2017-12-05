using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AppDemo2
{
    class Program
    {
        static void Main(string[] args)
        {

            WebClient webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            for (int i = 0; i < 10; i++)
            {
                Console.Write("请输入要查询的地址：");
                string searchAdd = Console.ReadLine().Trim();
                string UrlAdd = HttpUtility.UrlEncode(searchAdd);
                string url = "http://api.map.baidu.com/geocoder/v2/?address=" + UrlAdd + "&output=json&ak=RxlRV0IK9Rcd7QyIjXmhKH0CFIn1jntu";

                try
                {
                    string responseText = webClient.DownloadString(url);
                    GeoCoderResult geoCoderResult = Newtonsoft.Json.JsonConvert.DeserializeObject<GeoCoderResult>(responseText);

                    if (geoCoderResult.status == 0)
                    {
                        Console.WriteLine("[" + searchAdd + "]的经度为：" + geoCoderResult.result.location.lng);
                        Console.WriteLine("[" + searchAdd + "]的纬度为：" + geoCoderResult.result.location.lat);
                    }
                    else if (geoCoderResult.status == 1)
                    {
                        Console.WriteLine(geoCoderResult.msg);
                    }
                    else
                    {
                        Console.WriteLine("这是什么错误");
                    }

                    Console.WriteLine("返回结果Status：" + geoCoderResult.status);
                }
                catch (Exception)
                {
                    Console.WriteLine("异常了");
                }
            }



            Console.ReadLine();
        }
    }

    public class GeoCoderResult
    {
        public int status { get; set; }

        public Result result { get; set; }

        public string msg { get; set; }

        public IEnumerable<Result> results { get; set; }
    }

    public class Result
    {
        public Location location { get; set; }

        public int precise { get; set; }

        public int confidence { get; set; }

        public string level { get; set; }
    }

    public class Location
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

}
