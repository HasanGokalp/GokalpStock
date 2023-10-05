using Microsoft.AspNetCore.Mvc;

namespace GokalpStock.API.Controllers.Home
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
