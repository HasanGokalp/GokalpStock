using GokalpStock.Application.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace GokalpStock.API.Controllers.Billing
{
    public class BillingController : Controller
    {
        private readonly IHomeService _homeService;
        public BillingController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
