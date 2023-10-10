using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Accounts;
using GokalpStock.Application.Concrete.Models.RequestModels.Products;
using GokalpStock.Application.Concrete.Wrapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace GokalpStock.Application.Abstract.Service
{
    public interface IHomeService : IDisposable
    {
        #region Services
        IAccountService AccountService { get; }
        IProductService ProductService { get; }
        IBillingService BillingService { get; }
        #endregion
        //Sürekli çalışacak ana func, bütün bilgiler zaten account da olduğu için direkt account service den çekiliyor.
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

        #region Ürünler hakkında arama,filtreleme ve istatistik bilgileri
        Result<double> GetByFilterPopularity(string primary, string secondry);
        Result<List<ProductDto>> GetInAMonthByFilterProductName(string productName, string month);
        Result<List<ProductDto>> GetByFilterProductName(string productName);
        Result<double> DepartmentsWithTheMostOrders();
        Result<BillingDto> MostOfferedByMonth(string month);
        


        #endregion

        #region Talep tahmini

        double ExponentialSmoothing(double smoothingFactorOfData, int counter, int D, int F);
        Result<double> LinearRegression();
        #endregion

        #region Maliyet için matematiksel formüller
        Result<double> EconomicOrderQuantity(double K, double D, double G);
        #endregion

        #region Aşamalar için istatistik

        Result<double> MostAcceptedProducts();
        Result<ProductDto> MostRejectedProducts();
        Result<double> MeanTotalProcessingTime();
        Result<double> AverageTotalProcessingTimeByProducts();
        Result<double> AverageTotalProcessingTimeInAMonthByProducts(string month, string productName);
        Result<double> TotalProcessingTimeBySpesificProducts(string productName);
        Result<double> AverageTotalProcessingTimeBySpesificProducts(string productName);


        #endregion

        #region Yöneticiler için genel istatistikler
        //Utilization Rate Formula
        //Basit şekilde sistemi kullanma oranı
        Result<double> UtilizationRateFormula(string name);
        Result<double> CapacityUtilizationRate();
        Result<Dictionary<string, List<ProductDto>>> ABCAnalyze();
        Result<double> TargetUtilization();


        #endregion
        //Talep tahmini içinde kullanılan en basit yöntemler
        #region Ortalamalar yöntemi 

        #region Fiyata göre
        Result<double> ProductsPriceMean();
        Result<double> BillingPriceMean();
        #endregion

        #region Talep e göre
        Result<double> MeanDemandBillings();


        #endregion
        #endregion
    }
}
