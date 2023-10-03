using GokalpStock.Domain.Concrete;
using GokalpStock.Persistence.Abstract.Repository;
using GokalpStock.Persistence.Concrete.Context;

namespace GokalpStock.Persistence.Concrete.Repositories
{
    public class BillingRepository : Repository<Billing>, IBillingRepository
    {
        public BillingRepository(GokalpStockContext context) : base(context)
        {
        }
    }
}
