using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace TestSpider
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 注释以下
            ////http://www.cnblogs.com/wzk153/p/9145684.html
            //设置请求头参数
            Dictionary<string, string> headerOptions = new Dictionary<string, string>();
            headerOptions.Add("token", "0KA4OmEP6SscBTIXXXTGTJGsH0bD/VrsuNuIMNdiHkS2/TC1bdoSD0p7pCrugbvWUGEO2KjQJwQa+KNeqo7sbBwkqvL+NslbVeUnS/rdjRJHOCKmslStgl46h6qetOEVHVLSDwS8bqFjJbhHI7myF1sLIh1+58Ex9wnDgcx7+ipcx7U7cdgHYSGAeNpl3sQb9AyBVDuQYCyTZ9ShBeRaFMH/pJM4Uln627NWrPShDYM=");
            headerOptions.Add("unique_identity", "24c5e0f1-86a3-4078-af82-3d3ae53fe904");

            //设置请求参数  请求地址，请求方式(GET/POST) ?StartDate=2018-06-07&EndDate=2018-06-13&TrackStatisticsDateType=Day
            var requestOptions = new RequestOptions
            {
                Uri = new Uri("http://localhost:56493/api/Statistics/DriveCount"),
                Method = "POST",
                Miscellaneous = headerOptions
            };
            string result = RequestAction(requestOptions);
            Console.WriteLine(result);
            #endregion

            #region 抓取虎扑网页
            //Article article = new Article();

            ////设置请求的参数
            //var requestOptions = new RequestOptions { Uri = new Uri("https://bbs.hupu.com/22562974.html") };
            ////获取网页的源代码
            //var htmlString = RequestAction(requestOptions);
            ////加载源代码，获取页面的结构对象 需要引用HtmlAgilityPack
            //var doc = new HtmlDocument();
            //doc.LoadHtml(htmlString);

            //var resTitle = doc.DocumentNode.SelectSingleNode(@"/html[1]/head[1]/title[1]");
            //if (resTitle != null)
            //{
            //    article.Title = resTitle.InnerText;
            //}

            //var resAuthor = doc.DocumentNode.SelectSingleNode(@"/html[1]/body[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[2]/div[1]/div[1]/a[1]");

            //if (resAuthor != null)
            //{
            //    article.Author = resAuthor.InnerText;
            //}


            //var resContent1 = doc.DocumentNode.SelectSingleNode(@"/html[1]/body[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[2]/table[1]/tbody[1]/tr[1]/td[1]/div[2]/div[3]/font[1]");
            //if (resContent1 != null)
            //{
            //    article.Content = resContent1.InnerText;
            //}
            //var resContent2 = doc.DocumentNode.SelectSingleNode(@"/html[1]/body[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[2]/table[1]/tbody[1]/tr[1]/td[1]/div[2]/div[4]/font[1]");
            //if (resContent2 != null)
            //{
            //    article.Content += resContent2.InnerText;
            //}
            //var resContent3 = doc.DocumentNode.SelectSingleNode(@"/html[1]/body[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[2]/table[1]/tbody[1]/tr[1]/td[1]/div[2]/div[5]/font[1]");
            //if (resContent3 != null)
            //{
            //    article.Content += resContent3.InnerText;
            //}


            //if (article != null)
            //{
            //    Console.WriteLine($"文章标题为：{article.Title.Replace("\n", "").Trim()}\r\n");
            //    Console.WriteLine($"文章作者为：{article.Author}");
            //    Console.WriteLine($"文章内容为：{(HtmlToText(article.Content).Trim().Substring(0, 97) + "...")}\r\n");

            //}
            #endregion



            Console.WriteLine("Hello World!");
        }

        public static string HtmlToText(string Htmlstring)
        {
            if (string.IsNullOrWhiteSpace(Htmlstring)) return string.Empty;
            //string input = HTML;
            //return Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(input, @"(?m)<script[^>]*>(\w|\W)*?</script[^>]*>", "", RegexOptions.Multiline | RegexOptions.IgnoreCase), @"(?m)<style[^>]*>(\w|\W)*?</style[^>]*>", "", RegexOptions.Multiline | RegexOptions.IgnoreCase), @"(?m)<select[^>]*>(\w|\W)*?</select[^>]*>", "", RegexOptions.Multiline | RegexOptions.IgnoreCase), @"(?m)<a[^>]*>(\w|\W)*?</a[^>]*>", "", RegexOptions.Multiline | RegexOptions.IgnoreCase), "(<[^>]+?>)| ", "", RegexOptions.Multiline | RegexOptions.IgnoreCase), @"(\s)+", "", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([/r/n])[/s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "/", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "/xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "/xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "/xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "/xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(/d+);", "", RegexOptions.IgnoreCase);
            //替换掉 < 和 > 标记
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("/r/n", "");
            //返回去掉html标记的字符串
            return Htmlstring;
        }

        /// <summary>
        /// 文章类
        /// </summary>
        public class Article
        {
            /// <summary>
            /// 文章标题
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// 文章正文
            /// </summary>
            public string Content { get; set; }

            /// <summary>
            /// 文章作者
            /// </summary>
            public string Author { get; set; } = "无名氏";
        }


        private static string RequestAction(RequestOptions options)
        {
            string result = string.Empty;
            IWebProxy proxy = GetProxy();
            var request = (HttpWebRequest)WebRequest.Create(options.Uri);
            request.Accept = options.Accept;
            //在使用curl做POST的时候, 当要POST的数据大于1024字节的时候, curl并不会直接就发起POST请求, 而是会分为俩步,
            //发送一个请求, 包含一个Expect: 100 -continue, 询问Server使用愿意接受数据
            //接收到Server返回的100 - continue应答以后, 才把数据POST给Server
            //并不是所有的Server都会正确应答100 -continue, 比如lighttpd, 就会返回417 “Expectation Failed”, 则会造成逻辑出错.
            request.ServicePoint.Expect100Continue = false;
            request.ServicePoint.UseNagleAlgorithm = false;//禁止Nagle算法加快载入速度
            if (!string.IsNullOrEmpty(options.XHRParams)) { request.AllowWriteStreamBuffering = true; } else { request.AllowWriteStreamBuffering = false; }; //禁止缓冲加快载入速度
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");//定义gzip压缩页面支持

            //添加Header的参数
            if (options.Miscellaneous != null && options.Miscellaneous.Count > 0)
            {
                foreach (var item in options.Miscellaneous)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }

            request.ContentType = options.ContentType;//定义文档类型及编码
            request.AllowAutoRedirect = options.AllowAutoRedirect;//禁止自动跳转
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36";//设置User-Agent，伪装成Google Chrome浏览器
            request.Timeout = options.Timeout;//定义请求超时时间为5秒
            request.KeepAlive = options.KeepAlive;//启用长连接
            if (!string.IsNullOrEmpty(options.Referer)) request.Referer = options.Referer;//返回上一级历史链接
            request.Method = options.Method;//定义请求方式为GET
            if (proxy != null) request.Proxy = proxy;//设置代理服务器IP，伪装请求地址
            if (!string.IsNullOrEmpty(options.RequestCookies)) request.Headers[HttpRequestHeader.Cookie] = options.RequestCookies;
            request.ServicePoint.ConnectionLimit = options.ConnectionLimit;//定义最大连接数
            if (options.WebHeader != null && options.WebHeader.Count > 0) request.Headers.Add(options.WebHeader);//添加头部信息
            if (!string.IsNullOrEmpty(options.XHRParams))//如果是POST请求，加入POST数据
            {
                byte[] buffer = Encoding.UTF8.GetBytes(options.XHRParams);
                if (buffer != null)
                {
                    request.ContentLength = buffer.Length;
                    request.GetRequestStream().Write(buffer, 0, buffer.Length);
                }
            }
            request.ContentLength = 1000;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                ////获取请求响应
                //foreach (Cookie cookie in response.Cookies)
                //    options.CookiesContainer.Add(cookie);//将Cookie加入容器，保存登录状态
                if (response.ContentEncoding.ToLower().Contains("gzip"))//解压
                {
                    using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
                else if (response.ContentEncoding.ToLower().Contains("deflate"))//解压
                {
                    using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
                else
                {
                    using (Stream stream = response.GetResponseStream())//原始
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            }
            request.Abort();
            return result;
        }

        private class RequestOptions
        {
            /// <summary>
            /// 请求方式，GET或POST   默认GET
            /// </summary>
            public string Method { get; set; } = "GET";
            /// <summary>
            /// URL
            /// </summary>
            public Uri Uri { get; set; }
            /// <summary>
            /// 上一级历史记录链接
            /// </summary>
            public string Referer { get; set; }
            /// <summary>
            /// 超时时间（毫秒）
            /// </summary>
            public int Timeout = 15000;
            /// <summary>
            /// 启用长连接
            /// </summary>
            public bool KeepAlive = true;
            /// <summary>
            /// 禁止自动跳转
            /// </summary>
            public bool AllowAutoRedirect = false;
            /// <summary>
            /// 定义最大连接数
            /// </summary>
            public int ConnectionLimit = int.MaxValue;
            /// <summary>
            /// 请求次数
            /// </summary>
            public int RequestNum = 3;
            /// <summary>
            /// 可通过文件上传提交的文件类型
            /// </summary>
            public string Accept = "*/*";
            /// <summary>
            /// 内容类型
            /// </summary>
            public string ContentType = "application/x-www-form-urlencoded";
            /// <summary>
            /// 实例化头部信息
            /// </summary>
            private WebHeaderCollection header = new WebHeaderCollection();
            /// <summary>
            /// 头部信息
            /// </summary>
            public WebHeaderCollection WebHeader
            {
                get { return header; }
                set { header = value; }
            }
            /// <summary>
            /// 定义请求Cookie字符串
            /// </summary>
            public string RequestCookies { get; set; }
            /// <summary>
            /// 异步参数数据
            /// </summary>
            public string XHRParams { get; set; }
            /// <summary>
            /// 请求参数的Header键值对
            /// </summary>
            public Dictionary<string, string> Miscellaneous { get; set; }
        }

        private static System.Net.WebProxy GetProxy()
        {
            System.Net.WebProxy webProxy = null;
            //try
            //{
            //    // 代理链接地址加端口
            //    string proxyHost = "192.168.1.1";
            //    string proxyPort = "9030";

            //    // 代理身份验证的帐号跟密码
            //    //string proxyUser = "xxx";
            //    //string proxyPass = "xxx";

            //    // 设置代理服务器
            //    webProxy = new System.Net.WebProxy();
            //    // 设置代理地址加端口
            //    webProxy.Address = new Uri(string.Format("{0}:{1}", proxyHost, proxyPort));
            //    // 如果只是设置代理IP加端口，例如192.168.1.1:80，这里直接注释该段代码，则不需要设置提交给代理服务器进行身份验证的帐号跟密码。
            //    //webProxy.Credentials = new System.Net.NetworkCredential(proxyUser, proxyPass);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("获取代理信息异常", DateTime.Now.ToString(), ex.Message);
            //}
            return webProxy;
        }
    }
}
