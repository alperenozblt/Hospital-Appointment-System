using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemiii.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
