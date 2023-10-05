using AutoMapper;
using GokalpStock.Application.Abstract.Service;
using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Billings;
using GokalpStock.Application.Concrete.Validations.Billings;
using GokalpStock.Application.Concrete.Wrapper;
using GokalpStock.Domain.Concrete;
using GokalpStock.Persistence.Abstract.UnitWork;
using System.Linq.Expressions;

namespace GokalpStock.Application.Concrete.Service
{
    public class BillingService : IBillingService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public BillingService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public Result<bool> CreateBilling(CreateBillingsRM createBillingsRM)
        {
            var result = new Result<bool>();
            var validator = new CreateBillingsValidation();
            if (validator.Validate(createBillingsRM) != null)
            {
                var entity = _mapper.Map<Billing>(createBillingsRM);
                _unitWork.BillingRepository.Insert(entity);
                result.Data = true;
            }
            return result;
        }

        public Result<bool> DeleteBilling(DeleteBillingRM deleteBillingRM)
        {
            var result = new Result<bool>();
            var mappedEntity = _mapper.Map<Billing>(deleteBillingRM);
            _unitWork.BillingRepository.Delete(mappedEntity);
            if (mappedEntity != null)
            {
                
                result.Data = true;
            }
            return result;
        }

        public async Task<Result<List<BillingDto>>> GetAllBilling()
        {
            var result = new Result<List<BillingDto>>();
            var entities = await _unitWork.BillingRepository.GetAllAsync();
            var mappedEntity = _mapper.Map<IEnumerable<BillingDto>>(entities);
            if (mappedEntity != null)
            {
                result.Data = mappedEntity.ToList();
            }
            return result;
        }

        public Task<Result<List<BillingDto>>> GetByFilter(Expression<Func<BillingDto>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Result<bool> UpdateBilling(UpdateBillingRM updateBillingRM)
        {
            var result = new Result<bool>();
            //Önce girilen id ye göre doğrulama
            var tempEntity = _unitWork.BillingRepository.GetByFilter(x => x.AccountId == updateBillingRM.AccountId);
            if (tempEntity != null)
            {
                var tempMappedEntity = _mapper.Map<Billing>(updateBillingRM);
                var entity = _unitWork.BillingRepository.GetById(tempMappedEntity.Id);
                if (entity != null)
                {
                    result.Succsess = true;
                }
            }
            else { result.Succsess = false; throw new Exception("Bu isimde teklif bulunamadı"); }
            return result;
        }
    }
}
