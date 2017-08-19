using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Threading;
using System.Threading.Tasks;

using System.Net;
using System.Net.Http;

using Newtonsoft.Json;

namespace HomeAutomationMVC.Controllers
{
    public class ASController : AsyncController
    {
        private readonly object _lock = new object();

        public void IndexAsync()
        {
            AsyncManager.OutstandingOperations.Increment(2);
            //AsyncManager.Timeout = 60000;
            Operation1();
            Operation2();
        }
        public ActionResult IndexCompleted(string Operation1, string Operation2)
        {
            ViewData["Operation1"] = Operation1;
            ViewData["Operation2"] = Operation2;
            return View("Index");
        }

        /*public void GetTempAsync()
        {
            AsyncManager.OutstandingOperations.Increment(2);
            //AsyncManager.Timeout = 60000;

            Task<string> sCode = Task.Run(async () =>
            {
                string msg = await GetTempF();
                return msg;
            });            

        }
        public ActionResult GetTempCompleted(string Operation1, string Operation2)
        {
            ViewData["Operation1"] = Operation1;
            ViewData["Operation2"] = Operation2;
            return View("Index");
        }*/

        void Operation1()
        {
            lock (_lock)
            {
                AsyncManager.Parameters["Operation1"] = "Result1";
            }
            //last line of this method

            AsyncManager.OutstandingOperations.Decrement();
        }
        void Operation2()
        {
            lock (_lock)
            {
                AsyncManager.Parameters["Operation2"] = "Result2";
            }
            //last line of this method

            AsyncManager.OutstandingOperations.Decrement();
        }

        public async Task<ActionResult> GetTempF()
        {
            {
                // ... Target page.
                string page = "https://api.particle.io/v1/devices/3c002c000c47353136383631/tempFah?access_token=910e6334e063379fc1d3289298e85a2b7bbcd3d7";

                // ... Use HttpClient.
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(page);

                    string content = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        var model = JsonConvert.DeserializeObject<Models.RootObject>(content);
                        return View(model);
                    }

                    // an error occurred => here you could log the content returned by the remote server
                    return Content("An error occurred: " + content);
                }
            }
        }

    }
}
