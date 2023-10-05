using GokalpStock.Application.Abstract.Service;
using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Accounts;
using GokalpStock.Application.Concrete.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace GokalpStock.API.Controllers.Account
{
    [ApiController]
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly IHomeService _homeService;
        public AccountController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        [HttpGet("AccountLogin")]
        public async Task<ActionResult<Result<AccountDto>>> Login(LoginAccountRM loginAccountRM)
        {
            var entity = await _homeService.AccountService.Login(loginAccountRM);
            return Ok(entity);

        }
        [HttpPost("CreateAccount")]
        public ActionResult<Result<bool>> Create(CreateAccountRM createAccountRM)
        {
            var result = _homeService.AccountService.CreateAccount(createAccountRM);
            return Ok(result);
        }
        [HttpGet("GetAllAccount")]
        public async Task<ActionResult<Result<List<AccountDto>>>> GetAllAcount() 
        {
            var entities = await _homeService.AccountService.GetAll();
            return Ok(entities);
        }
        [HttpPost("UpdateAccount")]
        public ActionResult<Result<bool>> UpdateAccount(UpdateAccountRM updateAccountRM)
        {
            var result = _homeService.AccountService.UpdateAccount(updateAccountRM);
            return Ok(result);
        }
        [HttpPost("DeleteAccount")]
        public ActionResult<Result<bool>> DeleteAccount(DeleteAccountRM deleteAccountRM)
        {
            var result = _homeService.AccountService.DeleteAccount(deleteAccountRM);
            return Ok(result);
        }
    }
}
