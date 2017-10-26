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
            string status = "success";
            HomeAutomationMVC.Models.RelayStateModel relayStateModel = new Models.RelayStateModel();

            try
            {
                using (db = new ksalomon_listEntities())
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        ControlStatu record = db.ControlStatus.Where(
                                    x => x.ControlGroup == "RelayControlGroup"
                                        && x.ControlNumber == i
                                        && x.ControlType == "RelayControl").First();
                        if (record == null)
                        {
                            status = "No record found!";
                        }
                        //Convert nullable bool to bool
                        bool translatedBool = record.Status ?? false;

                        switch (i)
                        {
                            case 1:
                                relayStateModel.currentState1 = translatedBool;
                                break;
                            case 2:
                                relayStateModel.currentState2 = translatedBool;
                                break;
                            case 3:
                                relayStateModel.currentState3 = translatedBool;
                                break;
                            case 4:
                                relayStateModel.currentState4 = translatedBool;
                                break;
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                status = ex.ToString();
            }

            return View(relayStateModel);
        }

        public ActionResult Schedule()
        {
            return View();
        }

        [HttpPost]         
        public JsonResult RelayState(HomeAutomationMVC.Models.RelayStateModel relayStateModel)
        {
            string status = "success";
            int relayNumberToControl = 0;

            if (relayStateModel.selectControl.Contains("4"))
            { relayNumberToControl = 4; }
            else if (relayStateModel.selectControl.Contains("3"))
            { relayNumberToControl = 3; }
            else if (relayStateModel.selectControl.Contains("2"))
            { relayNumberToControl = 2; }
            else
            { relayNumberToControl = 1; }

            try
            {
                using (db = new ksalomon_listEntities())
                {
                    //Insert/Update new record
                    //db.ControlStatus.Add(new ControlStatu { CreatedDate = DateTime.Now, Status = true, Enabled = true, Description = relayStateModel.selectControl  });
                    ControlStatu record = db.ControlStatus.Where(
                        x => x.ControlGroup == "RelayControlGroup" && x.ControlNumber == relayNumberToControl && x.ControlType == "RelayControl").First();
                    if (record == null)
                    {
                        status = "No record found!";
                        throw new Exception(status);
                    }

                    record.Description = relayStateModel.selectControl;
                    record.Status = relayStateModel.selectControl.Contains("on") ? true : false;
                    record.UpdatedDate = DateTime.Now;

                    db.SaveChanges();

                }
            }
            catch(Exception ex)
            {
                status = ex.ToString();
            }

            Models.RelayStatusModel rsm = new Models.RelayStatusModel
            {
                Name = relayStateModel.selectControl,
                DateTime = DateTime.Now,
                responseText = status
            };

            return Json(rsm, JsonRequestBehavior.AllowGet);
        }

    }
}
