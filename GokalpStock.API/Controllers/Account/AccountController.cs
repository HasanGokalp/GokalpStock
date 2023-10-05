using Microsoft.AspNetCore.Mvc;

namespace GokalpStock.API.Controllers.Account
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
