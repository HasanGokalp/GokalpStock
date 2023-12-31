﻿using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Accounts;
using GokalpStock.Application.Concrete.Wrapper;
using System.Linq.Expressions;

namespace GokalpStock.Application.Abstract.Service
{
    public interface IAccountService
    {
        Task<Result<List<AccountDto>>> GetAll();
        Result<bool> CreateAccount(CreateAccountRM account);
        Result<bool> UpdateAccount(UpdateAccountRM account);
        Result<bool> DeleteAccount(DeleteAccountRM account);
        Task<Result<AccountDto>> GetById(int id);
        Task<Result<AccountDto>> Login(LoginAccountRM loginAccount);
        Task<Result<List<BillingDto>>> GetByFilter(Expression<Func<AccountDto>> filter = null);
        Result<AccountDto> LastCreatedAccount();
    }
}
