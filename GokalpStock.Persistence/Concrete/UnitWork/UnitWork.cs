using GokalpStock.Persistence.Abstract.Repository;
using GokalpStock.Persistence.Abstract.UnitWork;
using GokalpStock.Persistence.Concrete.Context;

namespace GokalpStock.Persistence.Concrete.UnitWork
{
    public class UnitWork : IUnitWork
    {
        private bool disposedValue;
        private readonly GokalpStockContext _context;

        public UnitWork(GokalpStockContext context, IAccountRepository accountRepository, IBillingRepository billingRepository, IProductRepository productRepository)
        {
            _context = context;
            AccountRepository = accountRepository;
            BillingRepository = billingRepository;
            ProductRepository = productRepository;
        }

        public IAccountRepository AccountRepository { get; }

        public IBillingRepository BillingRepository { get; }

        public IProductRepository ProductRepository { get; }

        public bool Commit()
        {
            var result = false;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChangesAsync();
                    transaction.CommitAsync();
                    result = true;
                }
                catch
                {
                    transaction.RollbackAsync();
                    throw;
                }
            }
            return result;
        }

        public async Task<bool> CommitAsync()
        {
            var result = false;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    result = true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: yönetilen durumu (yönetilen nesneleri) atın
                }

                // TODO: yönetilmeyen kaynakları (yönetilmeyen nesneleri) serbest bırakın ve sonlandırıcıyı geçersiz kılın
                // TODO: büyük alanları null olarak ayarlayın
                disposedValue = true;
            }
        }

        // // TODO: sonlandırıcıyı yalnızca 'Dispose(bool disposing)' içinde yönetilmeyen kaynakları serbest bırakacak kod varsa geçersiz kılın
        // ~UnitWork()
        // {
        //     // Bu kodu değiştirmeyin. Temizleme kodunu 'Dispose(bool disposing)' metodunun içine yerleştirin.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Bu kodu değiştirmeyin. Temizleme kodunu 'Dispose(bool disposing)' metodunun içine yerleştirin.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
