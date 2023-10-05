using GokalpStock.Application.Abstract.Service;
using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Accounts;
using GokalpStock.Application.Concrete.Models.RequestModels.Products;
using GokalpStock.Application.Concrete.Wrapper;

namespace GokalpStock.Application.Concrete.Service
{
    public class HomeService : IHomeService
    {
        private bool disposedValue;

        public IAccountService AccountService { get; }

        public IProductService ProductService {  get; }

        public IBillingService BillingService {  get; }

        public Task<Result<bool>> CreateAccount(CreateAccountRM createAccountRM)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> CreateBilling(CreateAccountRM createBillingRM)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> CreateProduct(CreateProductRM createProductRM)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteAccount(DeleteAccountRM deleteAccountRM)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteBilling(DeleteAccountRM deleteBillingRM)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteProduct(DeleteProductRM deleteProductRM)
        {
            throw new NotImplementedException();
        }

        public Task<Result<AccountDto>> GetAllInfo()
        {
            throw new NotImplementedException();
        }

        public Task<Result<AccountDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<AccountDto>> Login(LoginAccountRM loginAccount)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> UpdateAccount(UpdateAccountRM updateAccountRM)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> UpdateBilling(UpdateAccountRM updateBillingRM)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> UpdateProduct(UpdateProductRM updateProductRM)
        {
            throw new NotImplementedException();
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
        // ~HomeService()
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
