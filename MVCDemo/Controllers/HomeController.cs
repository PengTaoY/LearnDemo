using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return Content("&times=");

        }


        public ActionResult AutoComplate()
        {
            return View();
        }

        public ActionResult AutoData(string skeyword)
        {
            List<string> ls = new List<string>();
            ls.Add("ABC");
            ls.Add("CDE");
            ls.Add("DEF");
            return Json(ls, JsonRequestBehavior.AllowGet);

        }

        public class MyTest
        {
            public int Id { get; set; }

            public string ShortName { get; set; }
        }

    }
}