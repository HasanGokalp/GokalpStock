using GokalpStock.Domain.Concrete;
using GokalpStock.Persistence.Abstract.Repository;
using GokalpStock.Persistence.Concrete.Context;

namespace GokalpStock.Persistence.Concrete.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(GokalpStockContext context) : base(context)
        {
        }
    }
}
