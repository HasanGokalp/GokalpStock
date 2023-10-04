using GokalpStock.Application.Abstract.Service;
using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Products;
using GokalpStock.Application.Concrete.Wrapper;
using System.Linq.Expressions;

namespace GokalpStock.Application.Concrete.Service
{
    public class ProductService : IProductService
    {
        public Result<bool> CreateProduct(CreateProductRM createProductsRM)
        {
            throw new NotImplementedException();
        }

        public Result<bool> DeleteProduct(DeleteProductRM deleteProductRM)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetByFilter(Expression<Func<ProductDto>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Result<bool> UpdateProduct(UpdateProductRM updateProductRM)
        {
            throw new NotImplementedException();
        }
    }
}
