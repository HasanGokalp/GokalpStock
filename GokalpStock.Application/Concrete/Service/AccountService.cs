﻿using AutoMapper;
using GokalpStock.Application.Abstract.Service;
using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Accounts;
using GokalpStock.Application.Concrete.Validations.Accounts;
using GokalpStock.Application.Concrete.Wrapper;
using GokalpStock.Domain.Concrete;
using GokalpStock.Persistence.Abstract.UnitWork;

namespace GokalpStock.Application.Concrete.Service
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public AccountService(IUnitWork unitWork, IMapper mapper)
        {
            _unitWork = unitWork;
            _mapper = mapper;
        }

        public Result<bool> CreateAccount(CreateAccountRM account)
        {
            var result = new Result<bool>();
            var validator = new CreateAccountValidation();
            if (validator.Validate(account) != null)
            {
                var entity = _mapper.Map<CreateAccountRM, Account>(account);
                _unitWork.AccountRepository.Insert(entity);
                result.Data = true;
            }
            return result;
        }

        public Result<bool> DeleteAccount(DeleteAccountRM account)
        {
            var result = new Result<bool>();
            var validator = new DeleteAccountValidation();
            if (validator.Validate(account) != null)
            {
                var entity = _mapper.Map<DeleteAccountRM, Account>(account);
                if (entity != null)
                {
                    _unitWork.AccountRepository.Delete(entity);
                }
                result.Data = true;
            }
            return result;
        }

        public async Task<Result<List<AccountDto>>> GetAll()
        {
            var result = new Result<List<AccountDto>>();
            var entities = await _unitWork.AccountRepository.GetAllAsync();
            var convertedEntities = _mapper.Map<IEnumerable<Account>, IEnumerable<AccountDto>>(entities);
            if(convertedEntities != null)
            {
                result.Data = convertedEntities.ToList();
            }
            return result;
        }

        public async Task<Result<AccountDto>> GetById(int id)
        {
            var result = new Result<AccountDto>();
            var entity = await _unitWork.AccountRepository.GetByIdAsync(id);
            var convertedEntity = _mapper.Map<Account, AccountDto>(entity);
            if (convertedEntity != null)
            {
                result.Data = convertedEntity;
            }
            return result;
        }

        public Task<Result<bool>> Login(LoginAccountRM loginAccount)
        {
            var result = new Result<bool>();
            var entity = _unitWork.AccountRepository.GetByFilter(x => x.UserName == loginAccount.UserName && x.Password == loginAccount.Password); // T ^ T = T veya T ^ F = F 
            if (entity != null)
            {
                result.Succsess = true;
            }
            return Task.FromResult(result);
        }

        public Result<bool> UpdateAccount(UpdateAccountRM account)
        {
            var result = new Result<bool>();
            //Önce girilen id ye göre doğrulama
            var tempEntity = _unitWork.AccountRepository.GetByFilter(x => x.Name == account.Name);
            if (tempEntity != null)
            {
               var tempMappedEntity = _mapper.Map<UpdateAccountRM, Account>(account);
               var entity = _unitWork.AccountRepository.GetById(tempMappedEntity.Id);
                if (entity != null)
                {
                    result.Succsess = true;
                }
            }
            else { result.Succsess = false; throw new Exception("Bu isimde bir Kullanıcı bulunamadı"); }
            return result;
        }
    }
}
