using System;
using System.Collections.Generic;
using System.Text;

namespace CoreIntefaceDemo
{
    public interface ITest
    {
        IEnumerable<string> queryString(int sAmount);
    }
}
