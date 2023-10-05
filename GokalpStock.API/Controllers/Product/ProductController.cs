using Microsoft.AspNetCore.Mvc;

namespace GokalpStock.API.Controllers.Product
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
