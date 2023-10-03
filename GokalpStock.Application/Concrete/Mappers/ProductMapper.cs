using AutoMapper;
using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Products;
using GokalpStock.Domain.Concrete;

namespace GokalpStock.Application.Concrete.Mappers
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductRM, Product>();
            CreateMap<DeleteProductRM, Product>();
            CreateMap<UpdateProductRM, Product>();

        }
    }
}
