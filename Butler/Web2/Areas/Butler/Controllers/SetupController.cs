using ButlerWeb.Areas.Butler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ButlerWeb.Areas.Butler.Controllers
{
    [SetupOnly]
    public class SetupController : Controller
    {
        //
        // GET: /Butler/Setup/

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(User user)
        {
            return View();
        }


    }
}
