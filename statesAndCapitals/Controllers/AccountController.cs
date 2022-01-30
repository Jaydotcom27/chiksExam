using Microsoft.AspNetCore.Mvc;
using statesAndCapitals.Data;
using statesAndCapitals.Helpers;
using statesAndCapitals.Models;
using System.Net;

namespace statesAndCapitals.Controllers
{
    public class AccountController : Controller
    {
        private readonly StatesAndCapitalsContext _context;
        public AccountController(StatesAndCapitalsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
         
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            User user = _context.Users.ToList().FirstOrDefault(x => x.UserName == acc.UserName && x.Password == acc.Password);
            if (user != null)
            {
                Session.LogIn(user);
                return RedirectToAction("Test", "Test");
            }
            else
            {
                authCounter.addLoginAttempt();
                TempData["AlertMessage"] = "No matching account found";
                if (authCounter.checkLoginAttemps() == 3)
                {
                    TempData["AlertMessage"] = "If you insert wrong account information one more time the app will be terminated.";
                    return RedirectToAction(nameof(Login));

                } else if(authCounter.checkLoginAttemps() > 3)
                {
                    Environment.Exit(0);
                }
                return RedirectToAction(nameof(Login));
            }
        }

    }
}
