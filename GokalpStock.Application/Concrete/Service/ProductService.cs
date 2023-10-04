using AutoMapper;
using GokalpStock.Application.Abstract.Service;
using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Products;
using GokalpStock.Application.Concrete.Wrapper;
using GokalpStock.Domain.Concrete;
using GokalpStock.Persistence.Abstract.UnitWork;
using System.Linq.Expressions;

namespace GokalpStock.Application.Concrete.Service
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public ProductService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public Result<bool> CreateProduct(CreateProductRM createProductsRM)
        {
            var result = new Result<bool>();
            var mappedEntity = _mapper.Map<CreateProductRM, Product>(createProductsRM);
            _unitWork.ProductRepository.Insert(mappedEntity);
            if(mappedEntity != null)
            {
                result.Data = true;
            }
            return result;

        }

        public Result<bool> DeleteProduct(DeleteProductRM deleteProductRM)
        {
            var result = new Result<bool>();
            var mappedEntity = _mapper.Map<DeleteProductRM, Product>(deleteProductRM);
            _unitWork.ProductRepository.Delete(mappedEntity);
            if(mappedEntity != null)
            {
                result.Data = true;
            }
            return result;
        }

        public async Task<Result<List<ProductDto>>> GetAllProduct()
        {
            var result = new Result<List<ProductDto>>();
            var entities = await _unitWork.ProductRepository.GetAllAsync();
            var mappedEntity = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(entities);
            if(mappedEntity != null)
            {
                result.Data = mappedEntity.ToList();
            }
            return result;
        }

        public Task<Result<List<ProductDto>>> GetByFilter(Expression<Func<ProductDto>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Result<bool> UpdateProduct(UpdateProductRM updateProductRM)
        {
            var result = new Result<bool>();
            //Önce girilen id ye göre doğrulama
            var tempEntity = _unitWork.AccountRepository.GetByFilter(x => x.Name == updateProductRM.ProductName);
            if (tempEntity != null)
            {
                var tempMappedEntity = _mapper.Map<UpdateProductRM, Product>(updateProductRM);
                var entity = _unitWork.AccountRepository.GetById(tempMappedEntity.Id);
                if (entity != null)
                {
                    result.Succsess = true;
                }
            }
            else { result.Succsess = false; throw new Exception("Bu isimde bir ürün bulunamadı"); }
            return result;
        }
    }
}
