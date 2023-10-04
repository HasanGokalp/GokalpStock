using AutoMapper;
using GokalpStock.Application.Abstract.Service;
using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Billings;
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
            throw new NotImplementedException();
        }

        public Result<bool> DeleteBilling(DeleteBillingRM deleteBillingRM)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<BillingDto>>> GetAllBilling()
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<BillingDto>>> GetByFilter(Expression<Func<BillingDto>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Result<bool> UpdateBilling(UpdateBillingRM updateBillingRM)
        {
            var result = new Result<bool>();
            //Önce girilen id ye göre doğrulama
            var tempEntity = _unitWork.AccountRepository.GetByFilter(x => x.Name == updateBillingRM.Account.Name);
            if (tempEntity != null)
            {
                var tempMappedEntity = _mapper.Map<UpdateBillingRM, Billing>(updateBillingRM);
                var entity = _unitWork.AccountRepository.GetById(tempMappedEntity.Id);
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
