using GokalpStock.Application.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace GokalpStock.API.Controllers.Product
{
    public class ProductController : Controller
    {
        private readonly IHomeService _homeservice;
        public ProductController(IHomeService homeService)
        {
            _homeservice = homeService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
