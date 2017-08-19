using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeAutomationMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Environment Monitoring and Control";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Home Automation.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page.";

            return View();
        }
    }
}
