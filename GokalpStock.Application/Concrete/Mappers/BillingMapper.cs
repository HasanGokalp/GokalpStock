using AutoMapper;
using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Billings;
using GokalpStock.Domain.Concrete;

namespace GokalpStock.Application.Concrete.Mappers
{
    public class BillingMapper : Profile
    {
        public BillingMapper()
        {
            CreateMap<Billing, BillingDto>();
            CreateMap<CreateBillingsRM, Billing>();
            CreateMap<DeleteBillingRM, Billing>();
            CreateMap<UpdateBillingRM, Billing>();
            
        }
    }
}
