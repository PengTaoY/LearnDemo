
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreIntefaceDemo
{
    public class Test : ITest
    {
        public IEnumerable<string> queryString(int sAmount)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < sAmount; i++)
            {
                result.Add(i.ToString());
            }
            return result;
        }
    }


    public class Test2 : ITest
    {
        public IEnumerable<string> queryString(int sAmount)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < sAmount; i++)
            {
                result.Add((sAmount-i).ToString());
            }
            return result;
        }

        public string T()
        {
            return "Test2";
        }
    }
}
