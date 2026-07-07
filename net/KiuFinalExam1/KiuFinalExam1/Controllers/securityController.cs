using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KiuFinalExam1.Controllers
{
    public class securityController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        static Dictionary<String, String> users = new Dictionary<string, string>()
        {
            {"Mike" , "1234" },
            {"jake" , "1234" }
        };
        [HttpPost]
        public IActionResult Login(String UID , String PWD)
        {
            if (users.ContainsKey(UID) && users[UID]==PWD)

            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, UID) };
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity)).Wait();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Msg = "incorrect credentials";
                return Login();
            }
               
        }
    }
}
