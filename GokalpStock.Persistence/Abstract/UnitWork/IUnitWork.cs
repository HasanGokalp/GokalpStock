using GokalpStock.Persistence.Abstract.Repository;

namespace GokalpStock.Persistence.Abstract.UnitWork
{
    public interface IUnitWork : IDisposable
    {
        IAccountRepository AccountRepository { get; }
        IBillingRepository BillingRepository { get; }
        IProductRepository ProductRepository { get; }
        bool Commit();
        Task<bool> CommitAsync();
    }
}
