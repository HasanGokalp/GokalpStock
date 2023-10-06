using GokalpStock.Application.Abstract.Service;
using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Products;
using GokalpStock.Application.Concrete.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace GokalpStock.API.Controllers.Product
{
    [ApiController]
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly IHomeService _homeService;
        public ProductController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<Result<ProductDto>>> GetAllProducts()
        {
            var entities = await _homeService.ProductService.GetAllProduct();
            return Ok(entities);
        }
        [HttpPost("CreateProduct")]
        public ActionResult<Result<bool>> CreateProduct(CreateProductRM createProductRM)
        {
            var result = _homeService.ProductService.CreateProduct(createProductRM);
            return Ok(result);
        }
        [HttpPost("DeleteProduct")]
        public ActionResult<Result<bool>> DeleteProduct(DeleteProductRM deleteProductRM)
        {
            var result = _homeService.ProductService.DeleteProduct(deleteProductRM);
            return Ok(result);
        }
        [HttpPost("UpdateProduct")]
        public ActionResult<Result<bool>> UpdateProduct(UpdateProductRM updateProductRM)
        {
            var result = _homeService.ProductService.UpdateProduct(updateProductRM);
            return Ok(result);
        }
        [HttpGet("ProductsStatisticsPreferenceRate")]
        public ActionResult<Result<double>> GetProductPreferenceRate(string first, string second)
        {
            var result = _homeService.GetByFilterPopularity(first, second);
            return Ok(result);
        }
        [HttpGet("EconomicOrderQuantity")]
        public ActionResult<Result<double>> EconomicOrderQuantity(double K, double D, double G)
        {
            var result = _homeService.EconomicOrderQuantity(K, D, G);
            return Ok(result);
        }
    }
}
