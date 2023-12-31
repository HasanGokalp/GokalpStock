﻿using AutoMapper;
using GokalpStock.Application.Abstract.Service;
using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.EMail;
using GokalpStock.Application.Concrete.Models.RequestModels.Accounts;
using GokalpStock.Application.Concrete.Validations.Accounts;
using GokalpStock.Application.Concrete.Wrapper;
using GokalpStock.Domain.Concrete;
using GokalpStock.Persistence.Abstract.UnitWork;
using System.Linq.Expressions;

namespace GokalpStock.Application.Concrete.Service
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;
        private readonly IMailService _mailService;

        public AccountService(IUnitWork unitWork, IMapper mapper, IMailService mailService)
        {
            _unitWork = unitWork;
            _mapper = mapper;
            _mailService = mailService;
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

        public Task<Result<List<BillingDto>>> GetByFilter(Expression<Func<AccountDto>> filter = null)
        {
            throw new NotImplementedException();
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

        public Result<AccountDto> LastCreatedAccount()
        {
            var result = new Result<AccountDto>();
            var entities = _unitWork.AccountRepository.GetAll();
            var mapper = _mapper.Map<IEnumerable<AccountDto>>(entities);
            var filteredMappingEntity = mapper.SkipWhile(x => x.CreateDate <= DateTime.Now).OrderByDescending(x => x.CreateDate).SingleOrDefault();
            if (filteredMappingEntity != null)
            {
                result.Data = filteredMappingEntity;
            }
            else
            {
                result.Succsess = false;
            }
            return result;
        }

        public Task<Result<AccountDto>> Login(LoginAccountRM loginAccount)
        {
            var result = new Result<AccountDto>();
            var entity = _unitWork.AccountRepository.GetByFilter(x => x.UserName == loginAccount.UserName && x.Password == loginAccount.Password); // T ^ T = T veya T ^ F = F 
            if (entity != null)
            {
                result.Succsess = true;
                //Burada _mapper.Map<Account, AccountDto>(entity); değil _mapper.Map<Account>(loginAccount); gibi yapıldı.
                var mappedEntity = _mapper.Map<Account>(loginAccount);
                var modifiedMappedEntity = _mapper.Map<AccountDto>(mappedEntity);
                result.Data = modifiedMappedEntity;
                //_mailService.SendEmailAsync(new MailRequest()
                //{
                //    Body = "Hesabınıza giriş işlemi yapıldı.",
                //    Subject = "Uyarı",
                //    ToEmail = modifiedMappedEntity.Email
                //});
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
               var tempMappedEntity = _mapper.Map<Account>(account);
               var entity = _unitWork.AccountRepository.GetById(tempMappedEntity.Id);
                if (entity != null)
                {
                    //_mailService.SendEmailAsync(new MailRequest()
                    //{
                    //    Body = "Hesabınızın bilgileri değiştirildi.",
                    //    Subject = "Uyarı",
                    //    ToEmail = entity.Email
                    //});
                    result.Succsess = true;
                }
            }
            else { result.Succsess = false; throw new Exception("Bu isimde bir Kullanıcı bulunamadı"); }
            return result;
        }

    }
}
