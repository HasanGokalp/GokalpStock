using AutoMapper;
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

        public Task<Result<AccountDto>> GetByFilter()
        {
            throw new NotImplementedException();
        }

        public Task<Result<AccountDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> Login(LoginAccountRM loginAccount)
        {
            throw new NotImplementedException();
        }

        public Result<bool> UpdateAccount(UpdateAccountRM account)
        {
            throw new NotImplementedException();
        }
    }
}
