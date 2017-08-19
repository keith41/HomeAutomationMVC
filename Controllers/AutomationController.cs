using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeAutomationMVC.DAL;

namespace HomeAutomationMVC.Controllers
{
    [Authorize]
    public class AutomationController : Controller
    {
        //
        // GET: /Automation/

        private ksalomon_listEntities db = new ksalomon_listEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Scroll()
        {
            return View();
        }

        public ActionResult AysnResult()
        {
            return View();
        }

        public ActionResult Monitor()
        {            
            DateTime endDate = DateTime.Now.AddHours(-24);

            List<AutomationCloud> data = db.AutomationClouds.Where(x => x.CreatedDate >= endDate)
                .OrderBy(x => x.Id)
                .ToList();
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);            
        }

        public ActionResult Switch()
        {
            return View();
        }

    }
}
