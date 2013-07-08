using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        Authorization auth = new Authorization();

        [AllowAnonymous]
        public ActionResult Login() {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction("Index", "Snippet");
            }
            return View(); 
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User user) {

            var valid = false;
            foreach (var storedUser in auth.Users)
            {
                if (user.email == storedUser.email) {                    
                    // Validate password
                    valid = BCrypt.Net.BCrypt.Verify(user.password, storedUser.password);
                    break;
                }
            }

            if (valid) {
                // Create session
                FormsAuthentication.SetAuthCookie(user.email, false);
                
                // Roles?
                // Customer roleprovider?
                return RedirectToAction("Index", "Snippet");
            }
  
            return View();
        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Edit() {
            //if (user == null) {
               var user = new User();
            //}
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User newUser) {

            auth.AddUser(newUser);
            
            return View();
        }

    }
}

