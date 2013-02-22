using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class SnippetController : Controller
    {
        //
        // GET: /Snippet/

        public ActionResult Index()
        {
            List<Web.Models.Snippet> snippets = Butler.Store.GetAll<Web.Models.Snippet>();

            return View(snippets);
        }

        public ActionResult Edit(string id) {
            var snip = Butler.Store.Get<Web.Models.Snippet>(id);
            return View(snip);
        }

        [HttpPost]
        public ActionResult Edit(Web.Models.Snippet s) {
            Butler.Store.Save(s);
            ViewBag.Saved = true;
            return View(s);
        }

    }
}
