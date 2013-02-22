using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Models;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        Authorization auth = new Authorization();

        public ActionResult Index()
        {
            return View(new User());
        }

        public ActionResult Login() {
            return View(); 
        }

        [HttpPost]
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
            }
  
            return View();
        }

        public ActionResult Create() {
            var model = new User();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(User newUser) {

            auth.AddUser(newUser);
            
            return View();
        }

    }
}

