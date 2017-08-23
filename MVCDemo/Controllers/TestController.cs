using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index(int i, Guid g)
        {
            ViewData["g"] = g;
            ViewData["i"] = i;
            return View();
        }

        public JsonResult TestResult(int i, Guid g)
        {
            return Json(new { i = i, g = g },JsonRequestBehavior.AllowGet);

        }
    }
}