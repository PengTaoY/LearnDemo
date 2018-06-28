using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //泛型使用();
            //nnn();
            // Calculator();
            //TestList();
            //相差天数();
            //文字替换();
            //TaskTest();
            //序列化();
            //HTML操作();
            // var s = DateTime.Now.ToString("yyyy-MM-dd");
            // HTML操作2();
            //TryParseExact();
            //  ListFirstOrDefault();
            //IntRound();

            //dynamic dynamic;
            //dynamic = new { id = 1, name = "1" };
            //object obj = dynamic as object;
            //var properties = GetProperties(obj);

            //var columns = string.Join(",", properties);
            //var values = string.Join(",", properties.Select(p => "?" + p));





            Console.ReadKey();

        }


        private static void LinqSelect()
        {
            List<int> listint = new List<int> { 1, 2, 3 };

            Console.WriteLine(string.Join(",", listint));

            var listint2 = (from c in listint
                            select c + 2).ToList();
            Console.WriteLine(string.Join(",", listint2));

            List<LinqClass> linqClasses = new List<LinqClass> { };
            LinqClass linqClass1 = new LinqClass
            {
                Index = 1,
                Name = "第一个值"
            };

            LinqClass linqClass2 = new LinqClass
            {
                Index = 2,
                Name = "第二个值"
            };

            linqClasses.Add(linqClass1);
            linqClasses.Add(linqClass2);

            foreach (var item in linqClasses)
            {
                Console.WriteLine(item.Index + "  " + item.Name);
            }

            var dealer = (from c in linqClasses
                          where c.Index > 0
                          select c
                 ).FirstOrDefault();
            var testCar = (from c in linqClasses
                           orderby c.Index descending
                           select c
                                        ).FirstOrDefault();

            var testCar2 = (from c in linqClasses
                            orderby c.Index ascending
                            select c
                                        ).FirstOrDefault();
        }

        public class LinqClass
        {
            /// <summary>
            /// 索引
            /// </summary>
            public int Index { get; set; }

            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }
        }


        private static string TSalEEs(string input)
        {
            int[] array = { 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 4, 5, 2, 3, 4, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            StringBuilder hy = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 7 == 0)
                {
                    hy.Append("\n");
                }
                if (array[i] == 0)
                {
                    hy.Append("  ");
                }
                else if (array[i] == 4)
                {
                    hy.Append(" ");
                }
                else if (array[i] == 5)
                {
                    hy.Append(" I ");
                }
                else if (array[i] == 2)
                {
                    hy.Append("Love ");
                }
                else if (array[i] == 3)
                {
                    hy.Append("You");
                }
                else
                {
                    hy.Append("" + input);
                }
            }
            return hy.ToString();
        }


        #region GetProperties
        private static List<string> GetProperties(object obj, bool isRemoveNull = false)
        {
            if (obj == null)
            {
                return new List<string>();
            }
            //DynamicParameters  需要引用Dapper
            if (obj is DynamicParameters)
            {
                return (obj as DynamicParameters).ParameterNames.ToList();
            }
            if (isRemoveNull)
            {
                return GetPropertyInfos(obj).Where(x => x.GetValue(obj, null) != null).Select(x => x.Name).ToList();
            }
            else
            {
                return GetPropertyInfos(obj).Select(x => x.Name).ToList();
            }
        }

        public static List<PropertyInfo> GetPropertyInfos(object obj, bool isRemoveCustomAttr = true)
        {
            if (obj == null)
            {
                return new List<PropertyInfo>();
            }

            Type objType = obj.GetType();
            //取属性上的自定义特性
            var noMappingProperty = new List<string>();
            //foreach (PropertyInfo propInfo in objType.GetProperties())
            //{
            //    if (propInfo.GetCustomAttributes(typeof(Kina.Infrastructure.Utilities.UnMappingFieldAttribute), true).Any())
            //    {
            //        noMappingProperty.Add(propInfo.Name);
            //    }
            //}
            List<PropertyInfo> properties;
            //if (_paramCache.TryGetValue(obj.GetType(), out properties)) return properties.ToList();
            properties = obj.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public).ToList();

            if (noMappingProperty.Any() && isRemoveCustomAttr)
            {
                properties = properties.Where(s => !noMappingProperty.Contains(s.Name)).ToList();
            }
            // _paramCache[obj.GetType()] = properties;
            return properties;
        }

        #endregion


        /// <summary>
        /// int类型的数据四舍五入
        /// </summary>
        private static void IntRound()
        {
            int i = 3, j = 6;
            string s = Math.Round(((float)i / (float)j), 2) * 100 + "%";
        }






        /// <summary>
        /// 
        /// </summary>
        private static void ListFirstOrDefault()
        {
            List<AppContent> list = new List<AppContent> { new AppContent { img = "1.img", text = "1" }, new AppContent { img = "2.jpg", text = "2" } };

            var model = list.Select(u => u.text == "1").FirstOrDefault();

            var result = (from l in list where l.text == "1" select l).FirstOrDefault();


            Console.WriteLine();

        }

        public static string TryParseExact()
        {
            string time = "1/30/18 1:42:33 PM";
            IFormatProvider ifp = new CultureInfo("en-US", true);
            string[] formats = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt","M/d/yy h:mm:ss tt",
                         "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss",
                         "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt",
                         "M/d/yyyy h:mm", "M/d/yyyy h:mm",
                         "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm"};
            DateTime dateValue;
            try
            {
                dateValue = DateTime.ParseExact(time, formats, new CultureInfo("en-US"), DateTimeStyles.None);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            DateTime.TryParseExact(time, "M/dd/yy h:mm:ss tt", new CultureInfo("en-US"), DateTimeStyles.None, out DateTime dd);


            //String time = "1/30/18 1:42:33 PM";
            //DateTime dt = DateTime.ParseExact(time, "M/d/yy h:m:s tt", System.Globalization.CultureInfo.InvariantCulture);
            //Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss"));


            return "";
        }


        private static void HTML操作2()
        {
            string Html = "<div ><p>单纯的文本</p></div><div><img src=\"http://test-ethingnewsimg.oss-cn-qingdao.aliyuncs.com/24b409b40e5147e0a771e32e85dbbcb8.jpg\" /><p>图片嵌套的文本</p></div>";
            List<AppContent> result = new List<AppContent>();
            string pattern = @"<div([^^]*?)</div>";
            MatchCollection matchCollection = Regex.Matches(Html, pattern);
            foreach (Match item in matchCollection)
            {
                Console.WriteLine(item.Value);

                string pattImg = "src=\"";
                if (Regex.IsMatch(item.Value, pattImg))
                {
                    string pattImg2 = "src=\"([^^]*?)\"";
                    string Img = Regex.Match(item.Value, pattImg2).Value;
                    string resultImg = Regex.Replace(Img, "[\",src=]", "");

                    string pattText = "<p>([^^]*?)</p>";
                    string Text = Regex.Match(item.Value, pattText).Value;
                    string resultText = Regex.Replace(Text, "[<p></p>]", "");

                    AppContent content = new AppContent
                    {
                        img = resultImg,
                        text = resultText
                    };
                    result.Add(content);
                }
                else
                {
                    string resultText = Regex.Replace(item.Value, "[<div><p></p></div>]", "");
                    AppContent content = new AppContent
                    {
                        img = "",
                        text = resultText
                    };
                    result.Add(content);
                }

            }
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            Console.ReadKey();
        }

        private static void HTML操作()
        {
            string Html = "<div ><p>单纯的文本</p></div><div class=\"img\"><div><img src=\"http://test-ethingnewsimg.oss-cn-qingdao.aliyuncs.com/24b409b40e5147e0a771e32e85dbbcb8.jpg\" /><p>图片嵌套的文本</p></div></div>";
            List<AppContent> result = new List<AppContent>();
            string pattern = @"<div([^^]*?)</div>";
            MatchCollection matchCollection = Regex.Matches(Html, pattern);
            foreach (Match item in matchCollection)
            {
                Console.WriteLine(item.Value);

                string pattImg = "<div class=\"img\"";
                if (Regex.IsMatch(item.Value, pattImg))
                {
                    string pattImg2 = "src=\"([^^]*?)\"";
                    string Img = Regex.Match(item.Value, pattImg2).Value;
                    string resultImg = Regex.Replace(Img, "[\",src=]", "");

                    string pattText = "<p>([^^]*?)</p>";
                    string Text = Regex.Match(item.Value, pattText).Value;
                    string resultText = Regex.Replace(Text, "[<p></p>]", "");

                    AppContent content = new AppContent
                    {
                        img = resultImg,
                        text = resultText
                    };
                    result.Add(content);
                }
                else
                {
                    string resultText = Regex.Replace(item.Value, "[<div><p></p></div>]", "");
                    AppContent content = new AppContent
                    {
                        img = "",
                        text = resultText
                    };
                    result.Add(content);
                }

            }
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            Console.ReadKey();

        }



        private static void 序列化()
        {


            //var ob = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(input);

            //foreach (var item in ob)
            //{
            //    Console.WriteLine(item);
            //}

            List<string> list = new List<string>();
            list.Add("item1");
            list.Add("item2");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(list));

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);

            var ob = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(json);
            foreach (var item in ob)
            {
                Console.WriteLine(item);
            }


            ////////////////////////////////////////////////

            Dictionary<string, string> dt = new Dictionary<string, string>();
            dt.Add("word", "第一段文本");
            dt.Add("pic", "第一张图片");
            //dt.Add("word", "第二段文字");   //添加相同的键会报错

            string jsonD = Newtonsoft.Json.JsonConvert.SerializeObject(dt);

            var obD = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonD);


            /////////////////////////////////////////
            string nnn = Console.ReadLine();

            var ob2 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AppContent>>(nnn);
            foreach (var item in ob2)
            {
                Console.WriteLine("文字：" + item.text + "    图片：" + item.img);
            }

            var sss = Newtonsoft.Json.JsonConvert.SerializeObject(ob2);

            Console.WriteLine("我勒个去的");
        }

        public class AppContent
        {
            public string text { get; set; }
            public string img { get; set; }
        }


        private static void TaskTest()
        {
            var task1 = new Task(
                () => { Console.WriteLine("Hello,Task"); }

                );
            task1.Start();

            var task2 = Task.Factory.StartNew(() => { Console.WriteLine("Hello,task started by task factory"); });

            Console.ReadKey();
        }




        #region 让人疯的代码
        public class _____
        {
            public void ________(int[] ___)
            {
                int ____ = 0;
                for (int ______ = ___.Length - 1; ______ > 0; --______)
                {
                    for (int ________ = 0; ________ < ______; ++________)
                    {
                        if (___[________ + 1] < ___[________])
                        {
                            ____ = ___[________];
                            ___[________] = ___[________ + 1];
                            ___[________ + 1] = ____;
                        }
                    }
                }
            }
        }
        #endregion






        public static void 文字替换()
        {

            string str = "g";

            str = str.ToArray()[0].ToString() + new String('*', str.Length - 1);

            Console.WriteLine(str);
            String s = new String('*', str.Length - 1);


        }

        public static void 相差天数()
        {
            int ActivityDays = 0;
            DateTime StartDate = Convert.ToDateTime("2017-2-13 23:59:59");
            DateTime EndDate = Convert.ToDateTime("2017-2-14 00:59:59");

            ActivityDays = (Convert.ToDateTime(EndDate.ToShortDateString()) - Convert.ToDateTime(StartDate.ToShortDateString())).Days + 1;
            Console.WriteLine($"{StartDate}与{EndDate}相差天数为{ActivityDays}天");
        }

        public static void TestList()
        {
            List<MyUser> list = new List<MyUser>();
            MyUser u = new MyUser();
            for (int i = 0; i < 4; i++)
            {
                u.Id = i;
                u.Name = i.ToString();

                list.Add(u);
            }

            foreach (var item in list)
            {
                Console.WriteLine(item.Id + "  " + item.Name);
            }

            Console.WriteLine();

            List<MyUser> list2 = new List<MyUser>();

            for (int i = 0; i < 4; i++)
            {
                MyUser u2 = new MyUser();
                u2.Id = i;
                u2.Name = i.ToString();

                list2.Add(u2);
            }

            foreach (var item in list2)
            {
                Console.WriteLine(item.Id + "  " + item.Name);
            }
        }


        public static void Calculator()
        {
            string ss = "我的,天呢";

            string[] wwwss = ss.Split(',');


            //一个6位数乘以一个3位数，得到一个结果。但不清楚6位数的两个数字是什么，而且结果中有一位数字也不清楚，请编程找出问好代表的数字，答案可能有多个。
            //表达式：12 ? 56 ? *123 = 154 ? 4987

            //12?56?*123=154?4987
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if (((120000 + i * 1000 + 560 + j) * 123) == (15400000 + k * 10000 + 4987))
                        {
                            Console.WriteLine(string.Format("12{0}56{1}*123=154{2}4987", i, j, k));
                            Console.WriteLine($@"12{i}56{j}*123=154{k}4987");
                        }
                    }
                }
            }

            var sse = Enumerable.Range(0, 9).ToList().Select(w => long.Parse($"154{w}4987") / 123).Where(w => Regex.IsMatch(w.ToString(), "12\\d56\\d"));


        }

        public static string nnn()
        {
            int receive = 10;
            int publish = 3;

            // string nnn = Math.Round((((decimal)receive / (decimal)publish) * 100, 2, MidpointRounding.AwayFromZero).ToString();

            string bbb = (((double)receive / (double)publish) * 100).ToString();
            double dResult = (double)receive / (double)publish;
            string ccc = Math.Round(dResult, 4).ToString();

            return bbb;
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

        public static void NullTest(Guid g, int i)
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
                sb.AppendFormat("{0} ", item);
            }

            string s = sb.ToString();

            string a = "1";
            foreach (var item in a.Split(','))
            {
                ls.Add(item);
            }

            string ss = "";
        }

        public void Test1()
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


        public static void 泛型使用()
        {
            int obj = 2;
            泛型<int> test = new 泛型<int>(obj);
            Console.WriteLine("int:" + test.obj);

            string obj2 = "Hello world";
            泛型<string> test1 = new 泛型<string>(obj2);
            Console.WriteLine("String:" + test1.obj);
            Console.Read();
        }
    }

    public class 泛型<T>
    {
        public T obj;

        public 泛型(T obj)
        {
            this.obj = obj;
        }
    }


    public class User
    {
        public string ConnectionId { get; set; }

        public string Name { get; set; }

        public User(string name, string connectionId)
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
                if (balance >= amount)
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
