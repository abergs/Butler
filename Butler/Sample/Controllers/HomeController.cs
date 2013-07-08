using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Sample.Models.NewsStory news = ButlerCore.Store.Get<Sample.Models.NewsStory>("HomePageNews");
            return View(news);
        }

    }
}
