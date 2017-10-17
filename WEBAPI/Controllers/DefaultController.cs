using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEBAPI.Controllers
{
    /// <summary>
    /// 默认控制器
    /// </summary>
    public class DefaultController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "Get 到的  value为：" + id;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="value">参数</param>
        /// <returns>添加成功或失败</returns>
        public string Post(string value)
        {
            return value + "：添加成功";
        }
    }
}
