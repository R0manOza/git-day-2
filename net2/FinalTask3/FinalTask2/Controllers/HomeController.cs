using FinalTask2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalTask2.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult Sum(double p , double q)
        {
            return Json(new { r = p + q });
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
