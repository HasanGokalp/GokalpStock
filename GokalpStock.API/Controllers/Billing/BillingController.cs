using GokalpStock.Application.Abstract.Service;
using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Billings;
using GokalpStock.Application.Concrete.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace GokalpStock.API.Controllers.Billing
{
    [ApiController]
    [Route("Billing")]
    public class BillingController : Controller
    {
        private readonly IHomeService _homeService;
        public BillingController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        [HttpGet("GetAllBillings")]
        public async Task<ActionResult<Result<BillingDto>>> GetAllBillings()
        {
            var entities = await _homeService.BillingService.GetAllBilling();
            return Ok(entities);
        }
        [HttpPost("CreateBilling")]
        public ActionResult<Result<bool>> CreateBilling(CreateBillingsRM createBillingsRM)
        {
            var result = _homeService.BillingService.CreateBilling(createBillingsRM);
            return Ok(result);
        }
        [HttpPost("DeleteBilling")]
        public ActionResult<Result<bool>> DeleteBilling(DeleteBillingRM deleteBillingsRM)
        {
            var result = _homeService.BillingService.DeleteBilling(deleteBillingsRM);
            return Ok(result);
        }
        [HttpPost("UpdateBilling")]
        public ActionResult<Result<bool>> UpdateBilling(UpdateBillingRM updateBillingRM)
        {
            var result = _homeService.BillingService.UpdateBilling(updateBillingRM);
            return Ok(result);
        }

    }
}
