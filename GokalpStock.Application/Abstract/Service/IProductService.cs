using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Products;
using GokalpStock.Application.Concrete.Wrapper;
using System.Linq.Expressions;

namespace GokalpStock.Application.Abstract.Service
{
    public interface IProductService
    {
        Result<bool> CreateProduct(CreateProductRM createProductsRM);
        Result<bool> UpdateProduct(UpdateProductRM updateProductRM);
        Result<bool> DeleteProduct(DeleteProductRM deleteProductRM);
        Task<List<ProductDto>> GetAllProduct();
        Task<List<ProductDto>> GetByFilter(Expression<Func<ProductDto>> filter = null);
    }
}
