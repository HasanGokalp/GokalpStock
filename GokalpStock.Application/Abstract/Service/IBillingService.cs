using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Billings;
using GokalpStock.Application.Concrete.Wrapper;
using System.Linq.Expressions;

namespace GokalpStock.Application.Abstract.Service
{
    public interface IBillingService
    {
        Result<bool> CreateBilling(CreateBillingsRM createBillingsRM);
        Result<bool> UpdateBilling(UpdateBillingRM updateBillingRM);
        Result<bool> DeleteBilling(DeleteBillingRM deleteBillingRM);
        Task<List<BillingDto>> GetAllBilling();
        Task<List<BillingDto>> GetByFilter(Expression<Func<BillingDto>> filter = null);
    }
}
