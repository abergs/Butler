using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buttler.Models;

namespace Buttler.Areas.Buttler.Controllers
{   
    public class PagesController : Controller
    {
		private readonly IPageRepository pageRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public PagesController() : this(new PageRepository())
        {
        }

        public PagesController(IPageRepository pageRepository)
        {
			this.pageRepository = pageRepository;
        }

        //
        // GET: /Pages/

        public ViewResult Index()
        {
            return View(pageRepository.All);
        }

        //
        // GET: /Pages/Details/5

        public ViewResult Details(int id)
        {
            return View(pageRepository.Find(id));
        }

        //
        // GET: /Pages/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Pages/Create

        [HttpPost]
        public ActionResult Create(Page page)
        {
            if (ModelState.IsValid) {
                pageRepository.InsertOrUpdate(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Pages/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(pageRepository.Find(id));
        }

        //
        // POST: /Pages/Edit/5

        [HttpPost]
        public ActionResult Edit(Page page)
        {
            if (ModelState.IsValid) {
                pageRepository.InsertOrUpdate(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Pages/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(pageRepository.Find(id));
        }

        //
        // POST: /Pages/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            pageRepository.Delete(id);
            pageRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                pageRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

