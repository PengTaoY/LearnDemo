using System;

namespace 敏感词过滤2
{
    class Program
    {
        static void Main(string[] args)
        {
            FilterHelper filter = new FilterHelper(@"C:\Users\Administrator\Documents\Visual Studio 2017\Projects\LearnDemo\敏感词过滤2\badword.txt");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("请输入要检测的文本:");
                string sourceText = Console.ReadLine();

                filter.SourctText = sourceText.Trim();

                string resultStr = filter.Filter('*');

                Console.WriteLine("替换后的内容为：");
                Console.WriteLine(resultStr);

                Console.ReadKey();
            }
            
            
            Console.WriteLine("Hello World!");
        }
    }
}
