using Microsoft.AspNetCore.Mvc;

namespace GokalpStock.API.Controllers.Billing
{
    public class BillingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
