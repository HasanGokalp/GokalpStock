using GokalpStock.Domain.Concrete;
using GokalpStock.Persistence.Abstract.Repository;
using GokalpStock.Persistence.Concrete.Context;

namespace GokalpStock.Persistence.Concrete.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(GokalpStockContext context) : base(context)
        {
        }
    }
}
