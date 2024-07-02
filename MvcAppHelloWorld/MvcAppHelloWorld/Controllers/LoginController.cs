using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using _3_DataAccess;
using MvcAppHelloWorld.ViewModels;

namespace MvcAppHelloWorld.Controllers
{
    public class LoginController : Controller
    {
        private readonly TuxContext _context;

        public LoginController()
        {
            _context = new TuxContext();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users
                    .Include("UserRoles.Role")
                    .FirstOrDefault(u => u.Email == model.Email);

                if (user != null)
                {
                    if (user.Password == model.Password)
                    {
                        var roles = user.UserRoles.Select(ur => ur.Role.RoleName).ToArray();
                        var rolesString = string.Join(",", roles);

                        FormsAuthentication.SetAuthCookie(model.Email, false);

                        var authTicket = new FormsAuthenticationTicket(
                            1, model.Email, DateTime.Now, DateTime.Now.AddMinutes(30), false, rolesString);

                        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        Response.Cookies.Add(authCookie);

                        user.LastLogin = DateTime.Now;
                        _context.SaveChanges();

                        Session["UserRole"] = roles.Contains("HighSchoolLearner") ? "HighSchoolLearner" : "StudentLearner";

                        if (roles.Contains("HighSchoolLearner"))
                        {
                            return RedirectToAction("Index", "HighSchool");
                        }
                        else if (roles.Contains("StudentLearner"))
                        {
                            return RedirectToAction("Index", "Student");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Invalid password.");
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Invalid email.");
                }
            }

            return View(model);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["UserRole"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}
