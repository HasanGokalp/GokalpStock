using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Accounts;
using GokalpStock.Application.Concrete.Models.RequestModels.Products;
using GokalpStock.Application.Concrete.Wrapper;

namespace GokalpStock.Application.Abstract.Service
{
    public interface IHomeService : IDisposable
    {
        #region Services
        IAccountService AccountService { get; }
        IProductService ProductService { get; }
        IBillingService BillingService { get; }
        #endregion
        //Sürekli çalışacak ana func, bütün bilgiler zaten account da olduğu için direk account service den çekiliyor.
        #region Base funcs
        Task<Result<AccountDto>> GetAllInfo();

        #endregion
        
        #region Account işlemleri
        Task<Result<AccountDto>> GetById(int id);
        Task<Result<AccountDto>> Login(LoginAccountRM loginAccount);
        Task<Result<bool>> CreateAccount(CreateAccountRM createAccountRM);
        Task<Result<bool>> UpdateAccount(UpdateAccountRM updateAccountRM);
        Task<Result<bool>> DeleteAccount(DeleteAccountRM deleteAccountRM);
        #endregion

        #region Billing işlemleri
        Task<Result<bool>> CreateBilling(CreateAccountRM createBillingRM);
        Task<Result<bool>> UpdateBilling(UpdateAccountRM updateBillingRM);
        Task<Result<bool>> DeleteBilling(DeleteAccountRM deleteBillingRM);
        #endregion

        #region Product işlemleri
        Task<Result<bool>> CreateProduct(CreateProductRM createProductRM);
        Task<Result<bool>> UpdateProduct(UpdateProductRM updateProductRM);
        Task<Result<bool>> DeleteProduct(DeleteProductRM deleteProductRM);
        #endregion
    }
}
