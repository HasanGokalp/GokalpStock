using GokalpStock.Application.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace GokalpStock.API.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
