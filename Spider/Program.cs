using HtmlAgilityPack;
using Ivony.Html;
using Ivony.Html.Parser;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入网址：");
            string url = Console.ReadLine();
            var uri = new Uri(url);
            var browser1 = new ScrapingBrowser();
            var html1 = browser1.DownloadString(uri);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html1);
            var html = htmlDocument.DocumentNode;

            var title = html.CssSelect("title");
            int i = 1;
            foreach (var htmlNode in title)
            {
                Console.Write($"第{i}行：");
                Console.WriteLine(htmlNode.InnerHtml);
                i++;
            }

            var divs = html.CssSelect("div.postBody");
            foreach (var htmlNode in divs)
            {
                Console.WriteLine(htmlNode.InnerHtml);
            }

            //Basic examples of CssSelect usages:

            //var divs = html.CssSelect("div");  //all div elements

            //var nodes = html.CssSelect("div.content"); //all div elements with css class ‘content’

            //var nodes = html.CssSelect("div.widget.monthlist"); //all div elements with the both css class

            //var nodes = html.CssSelect("#postPaging"); //all HTML elements with the id postPaging

            //var nodes = html.CssSelect("div#postPaging.testClass"); // all HTML elements with the id postPaging and css class testClass 

            //var nodes = html.CssSelect("div.content > p.para"); //p elements who are direct children of div elements with css class ‘content’ 

            //var nodes = html.CssSelect("input[type=text].login"); // textbox with css class login 

            //We can also select ancestors of elements:

            //var nodes = html.CssSelect("p.para").CssSelectAncestors("div.content > div.widget");
















            //IHtmlDocument source = new JumonyParser().LoadDocument(url, Encoding.UTF8);
            //var aLinks = source.Find("meta");  //获取所有的meta标签

            Console.WriteLine("请重新开始你的表演");
        }
    }
}
