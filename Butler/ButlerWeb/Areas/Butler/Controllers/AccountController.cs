using System.Web.Mvc;
using System.Web.Security;
using ButlerWeb.Areas.Butler.Models;

namespace ButlerWeb.Areas.Butler.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        private readonly Authorization _auth = new Authorization();

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Welcome");
            }

            if (_auth.Users.Count == 0)
            {
                return RedirectToAction("Index", "Setup");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserViewModel user)
        {
            User validUser = null;
            foreach (User storedUser in _auth.Users)
            {
                if (user.Username == storedUser.Email || user.Username == storedUser.Name)
                {
                    // Validate password
                    if (BCrypt.Net.BCrypt.Verify(user.Password, storedUser.Password))
                    {
                        validUser = storedUser;
                    }
                    break;
                }
            }

            if (validUser != null)
            {
                // Create session
                FormsAuthentication.SetAuthCookie(validUser.Email, true);

                // Roles?
                // Customer roleprovider?
                return RedirectToAction("Index", "Welcome");
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            //if (user == null) {
            var user = new User();
            //}
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User newUser)
        {
            _auth.AddUser(newUser);

            return View();
        }

        public class UserViewModel : User
        {
            public string Username { get; set; }

            public UserViewModel()
            {

            }

            public UserViewModel(User user)
            {
                Username = user.Email;
                Password = user.Password;
            }
        }
    }
}