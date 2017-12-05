using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using System.Net;
using System.IO;

namespace AngleSharp使用
{
    class Program
    {
        static void Main(string[] args)
        {
            //找出所有文章标题 
            string cnblogsHtml = GetHtml();
            //加载HTML
            var document = DocumentBuilder.Html(cnblogsHtml);
            .Html

            //这里必须要使用== 不能使用Equals
            var titleItemList = document.All.Where(m => m.ClassName == "titlelnk");
            int iIndex = 1;
            foreach (var element in titleItemList)
            {
                Console.WriteLine(iIndex + ":" + element.InnerHtml);
                iIndex++;
            }
        }


        static public string GetHtml()
        {
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://www.cnblogs.com");
            HttpWebResponse response = (HttpWebResponse)myReq.GetResponse();
            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            return readStream.ReadToEnd();

        }

    }
}
