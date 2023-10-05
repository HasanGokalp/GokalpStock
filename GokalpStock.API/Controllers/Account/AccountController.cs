using GokalpStock.Application.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace GokalpStock.API.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly IHomeService _homeService;
        public AccountController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
