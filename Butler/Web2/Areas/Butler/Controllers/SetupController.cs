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
            return View("../Account/Create", new User());
        }


        [HttpPost]
        public ActionResult Index(User user)
        {
            var auth = new Authorization();
            auth.AddUser(user);
            return RedirectToAction("Login", "Account");
        }


    }
}
