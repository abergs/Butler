﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class SnippetController : Controller
    {
        //
        // GET: /Snippet/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create() {
            var s = new Web.Models.Snippet();
            return View(s);
        }

        [HttpPost]
        public ActionResult Create(Web.Models.Snippet s) {
            Buttler.Store.Save(s);
            return View();
        }

    }
}
