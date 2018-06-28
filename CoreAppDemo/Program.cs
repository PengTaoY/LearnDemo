using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //gps: 经度 long 116.53043,	纬度 lat 39.868879
            //高德: 116.536320258247,	39.870010036893
            double lon = 116.53043;
            double lat = 39.868879;
            // bd_decrpt(39.868879, 116.53043);

            transform(lat, lon, out double a, out double b);

            Console.WriteLine("Hello World!");
        }

        #region MyRegion
        const double pi = 3.14159265358979324;

        //  
        // Krasovsky 1940  
        //  
        // a = 6378245.0, 1/f = 298.3  
        // b = a * (1 - f)  
        // ee = (a^2 - b^2) / a^2;  
        const double a = 6378245.0;
        const double ee = 0.00669342162296594323;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wgLat"></param>
        /// <param name="wgLon"></param>
        /// <param name="mgLat"></param>
        /// <param name="mgLon"></param>
        public static void transform(double wgLat, double wgLon, out double mgLat, out double mgLon)
        {
            if (outOfChina(wgLat, wgLon))
            {
                mgLat = wgLat;
                mgLon = wgLon;
                return;
            }
            double dLat = transformLat(wgLon - 105.0, wgLat - 35.0);
            double dLon = transformLon(wgLon - 105.0, wgLat - 35.0);
            double radLat = wgLat / 180.0 * pi;
            double magic = Math.Sin(radLat);
            magic = 1 - ee * magic * magic;
            double sqrtMagic = Math.Sqrt(magic);
            dLat = (dLat * 180.0) / ((a * (1 - ee)) / (magic * sqrtMagic) * pi);
            dLon = (dLon * 180.0) / (a / sqrtMagic * Math.Cos(radLat) * pi);
            mgLat = wgLat + dLat;
            mgLon = wgLon + dLon;
        }

        static bool outOfChina(double lat, double lon)
        {
            if (lon < 72.004 || lon > 137.8347)
                return true;
            if (lat < 0.8293 || lat > 55.8271)
                return true;
            return false;
        }

        static double transformLat(double x, double y)
        {
            double ret = -100.0 + 2.0 * x + 3.0 * y + 0.2 * y * y + 0.1 * x * y + 0.2 * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * pi) + 20.0 * Math.Sin(2.0 * x * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(y * pi) + 40.0 * Math.Sin(y / 3.0 * pi)) * 2.0 / 3.0;
            ret += (160.0 * Math.Sin(y / 12.0 * pi) + 320 * Math.Sin(y * pi / 30.0)) * 2.0 / 3.0;
            return ret;
        }

        static double transformLon(double x, double y)
        {
            double ret = 300.0 + x + 2.0 * y + 0.1 * x * x + 0.1 * x * y + 0.1 * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * pi) + 20.0 * Math.Sin(2.0 * x * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(x * pi) + 40.0 * Math.Sin(x / 3.0 * pi)) * 2.0 / 3.0;
            ret += (150.0 * Math.Sin(x / 12.0 * pi) + 300.0 * Math.Sin(x / 30.0 * pi)) * 2.0 / 3.0;
            return ret;
        }
        #endregion


        /// <summary>
        /// 将百度地图坐标系，转换成高德地图坐标系
        /// BD-09（百度地图）转 GCJ-02(火星)
        /// </summary>
        /// <param name="bd_lat"></param>
        /// <param name="bd_lon"></param>
        public static void bd_decrpt(double bd_lat, double bd_lon)
        {
            double x = bd_lon - 0.0065, y = bd_lat - 0.006;
            double x_pi = 3.14159265358979324 * 3000.0 / 180.0;

            double z = Math.Sqrt(x * x + y * y) - 0.00002 * Math.Sin(y * x_pi);

            double theta = Math.Atan2(y, x) - 0.000003 * Math.Cos(x * x_pi);

            double gg_lon = z * Math.Cos(theta);

            double gg_lat = z * Math.Sin(theta);

            Console.WriteLine("转换完成");
        }

        /// <summary>
        /// 异步请求post（键值对形式,可等待的）
        /// </summary>
        /// <param name="uri">网络基址("http://localhost:59315")</param>
        /// <param name="url">网络的地址("/api/UMeng")</param>
        /// <param name="formData">键值对List<KeyValuePair<string, string>> formData = new List<KeyValuePair<string, string>>();formData.Add(new KeyValuePair<string, string>("userid", "29122"));formData.Add(new KeyValuePair<string, string>("umengids", "29122"));</param>
        /// <param name="charset">编码格式</param>
        /// <param name="mediaType">头媒体类型</param>
        /// <returns></returns>
        public static async Task<string> HttpPostAsync(string uri, string url, List<KeyValuePair<string, string>> formData = null, string charset = "UTF-8", string mediaType = "application/x-www-form-urlencoded")
        {

            string tokenUri = url;
            var client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            HttpContent content = new FormUrlEncodedContent(formData);
            content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
            content.Headers.ContentType.CharSet = charset;
            for (int i = 0; i < formData.Count; i++)
            {
                content.Headers.Add(formData[i].Key, formData[i].Value);
            }

            HttpResponseMessage resp = await client.PostAsync(tokenUri, content);
            resp.EnsureSuccessStatusCode();
            string token = await resp.Content.ReadAsStringAsync();
            return token;
        }

        private static void GetExtend()
        {
            string name = "1232131.xls";

            string nameExtend = name.Substring(name.LastIndexOf(".") + 1, (name.Length - name.LastIndexOf(".") - 1));
        }

        private static void StringSplit()
        {
            string str = "我爱北京天安门#####天安门";
            string str1 = str.Split("#####")[0];
            string str2 = str.Split("#####")[1];
        }

        private static void CreateTxt()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            //创建写入文件
            FileStream fs1 = new FileStream(path + "/" + Guid.NewGuid().ToString("N") + ".txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine("文本中的内容");
            sw.WriteLine("文本中\r\n的内容");
            sw.Close();
            fs1.Close();

        }


        /// <summary>
        /// 判断字符串是否是车牌号
        /// </summary>
        private static void RegexCarNumber()
        {
            string regexStr = @"^[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}[A-Z0-9]{4}[A-Z0-9挂学警港澳]{1}$";
            while (true)
            {
                Console.Write($"请输入车牌号："); string carNumber = Console.ReadLine();

                if (Regex.IsMatch(carNumber, regexStr))
                {
                    Console.WriteLine("检测通过！");
                }
                else
                {
                    Console.WriteLine("车牌号有误！");
                }
            }
        }
    }
}
