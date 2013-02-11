using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Buttler.Areas.Buttler.Controllers
{
    [Authorize (Roles="Admin, Manager")]
    public class DashboardController : Controller
    {
        //
        // GET: /Home/
        
        public ActionResult Index()
        {

            var model = Buttler.Client.ButtleClient.Get("welcome");
            if (model == null) {
                return View();
            }
            
            return View(model);
        }
    }
}
