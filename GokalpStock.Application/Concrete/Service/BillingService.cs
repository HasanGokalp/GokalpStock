using AutoMapper;
using GokalpStock.Application.Abstract.Service;
using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Billings;
using GokalpStock.Application.Concrete.Wrapper;
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

        public Task<List<BillingDto>> GetAllBilling()
        {
            throw new NotImplementedException();
        }

        public Task<List<BillingDto>> GetByFilter(Expression<Func<BillingDto>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Result<bool> UpdateBilling(UpdateBillingRM updateBillingRM)
        {
            throw new NotImplementedException();
        }
    }
}
