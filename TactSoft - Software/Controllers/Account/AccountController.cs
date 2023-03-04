using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using TactSoft.Core.Model.Account;
using TactSoft.Core.Model.ViewModel;
using TactSoft.Data.Data;

namespace TactSoft___Software.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly ApplicationDb _context;
        public AccountController(ApplicationDb context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.users.ToList());
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginSignUpVM login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _context.users.Where(e => e.UserName == login.UserName).SingleOrDefault();
                    if (data != null)
                    {
                        bool isValid = (data.UserName == login.UserName && data.Password == login.Password);
                        if (isValid)
                        {
                            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, login.UserName) }, CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                            HttpContext.Session.SetString("UserName", login.UserName);
                            return RedirectToAction("Index", "Dashboard");
                        }
                        else
                        {
                            TempData["errPass"] = "Invaild Password...!!";
                            return View(login);
                        }
                    }
                    else
                    {
                        TempData["errorlogin"] = "UserName is Invalid....!!";
                        return View(login);
                    }
                }
                else
                {
                    return View(login);
                }

            }
            catch
            {
                return View(login);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [AcceptVerbs("Post", "Get")]
        public IActionResult userNameIsExist(string userName)
        {
            var data = _context.users.Where(e => e.UserName == userName).SingleOrDefault();
            if (data != null)
            {
                return Json($"userName {userName} already in use..");
            }
            else
            {
                return Json(true);
            }
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpUserVM signup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = new UserModel()
                    {
                        UserName = signup.UserName,
                        Email = signup.Email,
                        Mobile = signup.Mobile,
                        Password = signup.Password
                    };
                    _context.users.Add(data);
                    _context.SaveChanges();
                    TempData["usersucc"] = "you are eligble to log in....";
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["emtp"] = "Empty can't submitted !!";
                    return View(signup);
                }
            }
            catch
            {
                return View(signup);
            }
        }

        public IActionResult Delete(int id)
        {
            var de = _context.users.Find(id);
            return PartialView("_delete", de);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(UserModel user, int id)
        {
            var de = _context.users.Find(id);
            if (de != null)
            {
                _context.users.Remove(de);
            }
            return View();
        }
    }
}
