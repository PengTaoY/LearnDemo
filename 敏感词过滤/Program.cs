using System;
using System.Collections.Generic;
using System.Linq;

namespace 敏感词过滤
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }


        /// <summary>
        /// 查询替换敏感词
        /// </summary>
        /// <param name="sourceText">原文内容</param>
        /// <param name="replaceStr">敏感词被替换成的字符串</param>
        /// <returns></returns>
        public static string FilterSensitiveWords2(this string sourceText, char replaceStr, List<string> outFilterList = null)
        {
            if (string.IsNullOrWhiteSpace(sourceText))
            {
                return string.Empty;
            }
            try
            {
                ICacheStrategy redisChache = new RedisCacheStrategy();
                var wordListG = redisChache.GetSenWords("ethingSenWord");
                return FilterSensitiveWords(sourceText, wordListG, replaceStr, outFilterList);
            }
            catch (Exception ex)
            {
                return sourceText;
            }

        }

        /// <summary>
        /// 敏感词替换
        /// </summary>
        /// <param name="sourceText"></param>
        /// <param name="sensitiveWords"></param>
        /// <param name="replace"></param>
        /// <param name="outFilterList"></param>
        /// <returns></returns>
        public static string FilterSensitiveWords(string sourceText, IEnumerable<string> sensitiveWords, char replace, List<string> outFilterList = null)
        {
            Dictionary<char, List<string>> dicList = new Dictionary<char, List<string>>();

            System.Text.StringBuilder sb = new System.Text.StringBuilder(sourceText.Length);
            string filterText = string.Join("|", sensitiveWords);
            //脏字 可根据自己的方式用分隔符
            string[] filterData = filterText.Split('|');
            foreach (var item in filterData)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    continue;
                }
                char value = item[0];
                if (dicList.ContainsKey(value))
                    dicList[value].Add(item);
                else
                    dicList.Add(value, new List<string>() { item });
            }
            int count = sourceText.Length;
            for (int i = 0; i < count; i++)
            {
                char word = sourceText[i];
                if (dicList.ContainsKey(word))//如果在字典表中存在这个key
                {
                    int num = 0;//是否找到匹配的关键字 1找到0未找到
                    var data = dicList[word].OrderBy(g => g.Length);
                    //把该key的字典集合按 字符数排序(方便下面从少往多截取字符串查找)
                    foreach (var wordbook in data)
                    {
                        if (i + wordbook.Length <= count)
                        //如果需截取的字符串的索引小于总长度 则执行截取
                        {
                            string result = sourceText.Substring(i, wordbook.Length);
                            //根据关键字长度往后截取相同的字符数进行比较
                            if (result == wordbook)
                            {
                                num = 1;
                                sb.Append(GetString(result));
                                i = i + wordbook.Length - 1;
                                if (outFilterList != null) outFilterList.Add(result);
                                //比较成功 同时改变i的索引
                                break;
                            }
                        }
                    }
                    if (num == 0)
                        sb.Append(word);
                }
                else
                    sb.Append(word);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 替换星号
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static string GetString(string value)
        {
            string starNum = string.Empty;
            for (int i = 0; i < value.Length; i++)
            {
                starNum += "*";
            }
            return starNum;
        }
    }



}
