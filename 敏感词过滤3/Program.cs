using System;

namespace 敏感词过滤3
{
    class Program
    {
        static void Main(string[] args)
        {
            //敏感词词库
            string s = "中国|国家人|zg人|64";
            //要检测的语句
            string test = "我是中国人，我参与了64事件";

            StringSearch iwords = new StringSearch();
            iwords.SetKeywords(s.Split('|'));

            var b = iwords.ContainsAny(test);

            var f = iwords.FindFirst(test);
            ////Assert.AreEqual("中国", f);

            var all = iwords.FindAll(test);
            ////Assert.AreEqual("中国", all[0]);
            ////Assert.AreEqual("国人", all[1]);
            ////Assert.AreEqual(2, all.Count);

            var str = iwords.Replace(test, '*');


            Console.WriteLine($"原字符串：{test} \r\n替换过后：{str}");

            Console.ReadKey();
        }
    }
}
