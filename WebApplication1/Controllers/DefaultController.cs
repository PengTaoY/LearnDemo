using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }



        public JsonResult Result()
        {
            List<int> list = new List<int> { 5, 10, 10, 15, 20, 40 };

            var res = Get_Rand(list);


            return Json(new { status = 2, msg = "您抽取了三等奖" });
        }

        private int Get_Rand(List<int> list)
        {
            var result = 0;

            var proSum = 0;
            foreach (var item in list)
            {
                proSum += item;
            }



            return result;
        }
    }
}