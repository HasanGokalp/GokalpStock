using AutoMapper;
using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Accounts;
using GokalpStock.Domain.Concrete;

namespace GokalpStock.Application.Concrete.Mappers
{
    public class AccountMapper : Profile
    {
        public AccountMapper()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<CreateAccountRM, Account>();
            CreateMap<UpdateAccountRM, Account>();
            CreateMap<DeleteAccountRM, Account>();
            CreateMap<LoginAccountRM, Account>();
        }
    }
}
