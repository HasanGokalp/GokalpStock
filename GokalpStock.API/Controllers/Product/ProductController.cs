using GokalpStock.Application.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace GokalpStock.API.Controllers.Product
{
    public class ProductController : Controller
    {
        private readonly IHomeService _homeService;
        public ProductController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
