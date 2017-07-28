using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string guid = Guid.NewGuid().ToString("N").Substring(0, 12);

            DateTime dt1 = DateTime.Now;
            DateTime dt2 = dt1.AddSeconds(10);
            long sp1 = dt1.Ticks;
            long sp2 = dt2.Ticks;


            //File.WriteAllText(@"D:\TempResult.txt", "临时内容", Encoding.UTF8);

            //var sr = new StreamReader(@"D:\TempResult.txt", Encoding.UTF8);
            //string test = sr.ReadToEnd();
            //string test2 = sr.ReadLine();



            int? count = 2;
            string strWhere = " 1=1 ";
            string sql =
               string.Format(@"SELECT  detail.ImageWidth,detail.ImageHeight,IsCarousel,ImageSrc,TargeUrl,AdTitle,img.AdImageId , ir.RegionId
                                FROM Ad_Image img
                                INNER JOIN Ad_TemplateDetail detail ON img.TemplateDetailId=detail.TemplateDetailId 
                                INNER JOIN Ad_Template t ON t.TemplateId=detail.TemplateId
                                left join Ad_ImageRegion ir on img.AdImageId=ir.AdImageId
                                WHERE {1}
                                Order BY img.CreateDate DESC  
                                {0}
",
                               count.HasValue ? "LIMIT 0," + count : string.Empty,
                               strWhere);
            Console.ReadKey();

        }
    }
}
