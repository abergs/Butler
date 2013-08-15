using System.Web.Mvc;
using ButlerWeb.Areas.Butler.Models;
using System.Web.Security;

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

            // Create session
            FormsAuthentication.SetAuthCookie(user.Email, true);
            
            return RedirectToAction("Login", "Account");
        }
    }
}