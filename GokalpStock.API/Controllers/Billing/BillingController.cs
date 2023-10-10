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
        [HttpGet("MostOfferedByMonth")]
        public ActionResult<Result<ProductDto>> MostOfferedByMonth(string month)
        {
            var result = _homeService.MostOfferedByMonth(month);
            return Ok(result);
        }
        [HttpGet("BillingPriceMean")]
        public ActionResult<Result<double>> BillingPriceMean()
        {
            var result = _homeService.BillingPriceMean();
            return Ok(result);
        }
        [HttpGet("ExponentialSmoothing")]
        public ActionResult<Result<double>> ExponentialSmoothing(double smoothingFactorOfData, int counter, int D, int F)
        {
            var result = _homeService.ExponentialSmoothing(smoothingFactorOfData, counter, D, F);
            return Ok(result);
        }
        [HttpGet("MeanTotalProcessingTime")]
        public ActionResult<Result<double>> MeanTotalProcessingTime()
        {
            var result = _homeService.MeanTotalProcessingTime();
            return Ok(result);
        }
    }
}
