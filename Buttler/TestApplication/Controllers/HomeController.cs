using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = new Models.MyModel();
            model.ID = "welcome";

            model.Content = "Hello World!!";
            model.Title = "Welcome!";

            Butler.Store.Save(model);


            Models.MyModel retrieved = Butler.Store.Get<Models.MyModel>("welcome");

            return View(retrieved);
        }

    }
}
