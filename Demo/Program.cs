using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            内插字符串();

            Console.ReadKey();

        }



        public static void 内插字符串()
        {
            var name = "Horace";
            var age = 34;
            var s1 = $"He asked, \"Is your name {name}?\", but didn't wait for a reply.";
            Console.WriteLine(s1);

            var s2 = $"{name} is {age:D3} year{(age == 1 ? "" : "s")} old.";
            Console.WriteLine(s2);

        }

        public static void UseTranscationScope()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                Console.WriteLine("ts开始");

                var user = new MyUser();
                user = null;
                Console.WriteLine(user.Id);

                ts.Complete();
            }



        }

        /// <summary>
        /// Dictionary 字典操作
        /// </summary>
        public static void DictOp()
        {
            Dictionary<string, List<User>> room_user = new Dictionary<string, List<User>>();
            User u = new User("1", "connectionId1");
            User u2 = new User("2", "connectionId2");
            room_user.Add("room1", new List<User>());

            room_user["room1"].Add(u);
            room_user["room1"].Add(u2);
            Console.ReadKey();
        }

        public static void Sql拼接()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);



            string sql = string.Format("SELECT c.* FROM Act_ActivityComment c  WHERE CommentId IN('{0}')",
               string.Join("','", list));

            int a = 1;
        }

        public static void NullTest(Guid g,int i)
        {
            Console.WriteLine(g);
            Console.WriteLine(i);
        }

        public static void DateTimeOp()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy.mm.dd HH:mm:ss"));


        }

        public static void EnumOper()
        {
            foreach (var value in Enum.GetValues(typeof(EnumTest)))
            {
                object[] objAttrs = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objAttrs != null &&
                    objAttrs.Length > 0)
                {
                    DescriptionAttribute descAttr = objAttrs[0] as DescriptionAttribute;
                    Console.WriteLine(string.Format("[{0}]", descAttr.Description));
                }
                Console.WriteLine(string.Format("{0}={1}", value.ToString(), Convert.ToInt32(value)));
            }

        }


        private static void ListToString()
        {
            List<string> ls = new List<string>
            {
                "2",
                "3"
            };
            StringBuilder sb = new StringBuilder();
            foreach (var item in ls)
            {
                sb.AppendFormat("{0} ",item);
            }

            string s =  sb.ToString();

            string a = "1";
            foreach (var item in a.Split(','))
            {
                ls.Add(item);
            }

            string ss = "";
        }

        public void Test1 ()
        {
            string guid = Guid.NewGuid().ToString("N").Substring(0, 12);

            DateTime dt1 = DateTime.Now;
            DateTime dt2 = dt1.AddSeconds(10);
            long sp1 = dt1.Ticks;
            long sp2 = dt2.Ticks;

        }

        public void Sql()
        {
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
        }

        public void IOOper()
        {
            File.WriteAllText(@"D:\TempResult.txt", "临时内容", Encoding.UTF8);

            var sr = new StreamReader(@"D:\TempResult.txt", Encoding.UTF8);
            string test = sr.ReadToEnd();
            string test2 = sr.ReadLine();
        }

        public void Url()
        {
            string s = @"http://shop.ething.net/Product/Detail?dealerid=&productid=171";

            //char[] arr = s.ToCharArray();

            if (s.Contains("productid=") && s.Contains("dealerid=") && s.Contains("?"))
            {
                string sproductid = string.Empty, sdealerid = string.Empty;
                int productidStart = 0, productidEnd = 0;
                productidStart = s.IndexOf("productid=") + 10;

                if (s.IndexOf('&', productidStart) == -1)
                {
                    sproductid = s.Substring(productidStart);
                }
                else
                {
                    productidEnd = s.IndexOf('&', productidStart);
                    sproductid = s.Substring(productidStart, productidEnd - productidStart);
                }


                int dealeridStart = 0, dealeridEnd = 0;
                dealeridStart = s.IndexOf("dealerid=") + 9;

                if (s.IndexOf('&', dealeridStart) == -1)
                {
                    sdealerid = s.Substring(dealeridStart);
                }
                else
                {
                    dealeridEnd = s.IndexOf('&', dealeridStart);
                    sdealerid = s.Substring(dealeridStart, dealeridEnd - dealeridStart);
                }
            }
        }
    }

    public class User
    {
        public string ConnectionId { get; set; }

        public string Name { get; set; }

        public User(string name,string connectionId)
        {
            this.Name = name;
            this.ConnectionId = connectionId;
        }

    }

    public class MyUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Lock 相关的操作
    /// </summary>
    class Account
    {
        private Object thislock = new object();
        int balance;

        Random r = new Random();

        public Account(int initial)
        {
            balance = initial;
        }

        int WithDraw(int amount)
        {
            // This condition never is true unless the lock statement
            // is commented out.
            if (balance < 0)
            {
                throw new Exception("Negative Balance");
            }

            // Comment out the next line to see the effect of leaving out 
            // the lock keyword.
            lock (thislock)
            {
                if (balance >=amount)
                {
                    Console.WriteLine("Balance before Withdrawal :  " + balance);
                    Console.WriteLine("Amount to Withdraw        : -" + amount);
                    balance = balance - amount;
                    Console.WriteLine("Balance after Withdrawal  :  " + balance);
                    return amount;
                }
                else
                {
                    return 0;       // transaction rejected
                }
            }

        }

        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                WithDraw(r.Next(1, 100));
            }
        }
    }

    public enum EnumTest
    {
        /// <summary>
        /// 免费
        /// </summary>
        [Description("免费领取")]
        Free = 0,

        /// <summary>
        /// 积分兑换
        /// </summary>
        [Description("积分兑换")]
        PointExchange = 1
    }
}
