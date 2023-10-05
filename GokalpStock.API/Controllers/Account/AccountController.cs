using GokalpStock.Application.Abstract.Service;
using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Accounts;
using GokalpStock.Application.Concrete.Service;
using GokalpStock.Application.Concrete.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace GokalpStock.API.Controllers.Account
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly IHomeService _homeService;
        public AccountController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        [HttpGet("accountLogin")]
        public async Task<ActionResult<Result<AccountDto>>> Login(LoginAccountRM loginAccountRM)
        {
            var entity = await _homeService.AccountService.Login(loginAccountRM);
            return Ok(entity);

        }
        [HttpPost("createAccount")]
        public ActionResult<Result<bool>> Create(CreateAccountRM createAccountRM)
        {
            var result = _homeService.AccountService.CreateAccount(createAccountRM);
            return Ok(result);
        }
    }
}
