using GokalpStock.Application.Abstract.Service;
using GokalpStock.Application.Concrete.Models.Dtos;
using GokalpStock.Application.Concrete.Models.RequestModels.Accounts;
using GokalpStock.Application.Concrete.Models.RequestModels.Products;
using GokalpStock.Application.Concrete.Wrapper;
using System.Globalization;

namespace GokalpStock.Application.Concrete.Service
{
    public class HomeService : IHomeService
    {
        private bool disposedValue;

        public IAccountService AccountService { get; }

        public IProductService ProductService {  get; }

        public IBillingService BillingService {  get; }

        public HomeService(IAccountService accountService, IProductService productService, IBillingService billingService)
        {
            AccountService = accountService;
            ProductService = productService;
            BillingService = billingService;
        }
        #region CRUD
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
        #endregion

        #region DİSPOSE
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
        #endregion

        public Result<double> GetByFilterPopularity(string primary, string secondry)
        {
            var result = new Result<double>();
            var allEntity = ProductService.GetAllProduct();
            //Böl ve fethet
            var first = allEntity.Result.Data.Where(x => x.ProductName.ToLower().Contains(primary.ToLower()));
            var countFirst = first.Count();
            var second = allEntity.Result.Data.Where(x => x.ProductName.ToLower().Contains(secondry.ToLower()));
            var countSecond = first.Count();
            if(countFirst != 0 && countSecond != 0)
            {
                double ratio = countSecond / countFirst;
                result.Data = ratio;
            }
            else
            {
                result.Data = 0.0;
            }
            return result;

        }
        //Ekonomik sipariş miktarı, bir tedarikçiye ne zaman ve ne miktarda sipariş verileceğini belirleyen bir lojistik kavramıdır.Kısaca EOQ formülü, ne zaman ve ne miktarda sipariş verileceğini belirler.Q = optimal order quantity
        //K = cost of placing each order, her siparişi verme maliyeti
        //D = annual demand quantity of the raw material / product, hammadde / ürünün yıllık talep miktarı
        //G = cost of storing the raw material in the warehouse, hammaddenin depoda depolanması maliyeti
        public Result<double> EconomicOrderQuantity(double K, double D, double G)
        {
            var result = new Result<double>();
            var x = 2 * K * D;
            if(x != 0 && G != 0)
            {
                var y = x / G;
                var optimalOrderQuantity = Math.Sqrt(y);
                result.Data = optimalOrderQuantity;
            }
            else { result.Data = 0.0; }
    
            return result;
        }

        public Result<double> DepartmentsWithTheMostOrders()
        {
            throw new NotImplementedException();
        }
        //Kabul edilen ürünlerin tüm ürünlerin yüzde kaçını oluşturuyor.
        public Result<double> MostAcceptedProducts()
        {
            var result = new Result<double>();
            var acceptedProducts = BillingService.GetAllBilling();
            var mostAcceptedProd =  acceptedProducts.Result.Data.GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key).ToList();
            var entitycount = acceptedProducts.Result.Data.Count;
            if(entitycount == 0 && mostAcceptedProd.Count == 0)
            {
                var number = result.Data = mostAcceptedProd.Count / entitycount;
                result.Data = number;
                
            }
            else
            {
                result.Data = 0.0;
            }
            return result;

        }

        public Result<List<ProductDto>> GetInAMonthByFilterProductName(string productName, string month)
        {
            var list = new Result<List<ProductDto>>();
            var entities = ProductService.GetAllProduct();
            var dt = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month;
            var filteredEntities = entities.Result.Data.Select(x => x).Where(x => x.CreateDate.Month == dt).ToList();
            if (filteredEntities != null)
            {
                list.Data = filteredEntities;
            }
            return list;
        }

        public Result<List<ProductDto>> GetByFilterProductName(string productName)
        {
            var list = new Result<List<ProductDto>>();
            var entity = ProductService.GetAllProduct();
            var searchedEntity = entity.Result.Data.Select(x => x).Where(x => x.ProductName.Contains(productName)).ToList();
            if (searchedEntity != null)
            {
                list.Data = searchedEntity;
            }
            return list;
           
        }

        public Result<BillingDto> MostOfferedByMonth(string month)
        {
            var list = new Result<BillingDto>();
            var dt = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month;
            var entities = BillingService.GetAllBilling();
            var filteredEntity = entities.Result.Data.Select(x => x).OrderByDescending(x => x.CreateDate).Where(x => x.CreateDate.Month == dt).FirstOrDefault();
            if (filteredEntity != null)
            {
                list.Data = filteredEntity;
            }
            return list;
        }

        public double ExponentialSmoothing(double smoothingFactorOfData, int counter, int D, int F)
        {
     
            double formula = smoothingFactorOfData * D +( 1 - smoothingFactorOfData) * F;
            if (counter == 0)
            {
                return 1;
            }
            else
            {
                ExponentialSmoothing(smoothingFactorOfData , --counter, D, F);
            }
            return formula;
           

        }

        public Result<double> LinearRegression()
        {
            throw new NotImplementedException();
        }

        public Result<ProductDto> MostRejectedProducts()
        {
            var result = new Result<double>();
            var entities = ProductService.GetAllProduct();
            throw new NotImplementedException();
        }

        public Result<double> MeanTotalProcessingTime()
        {
            throw new NotImplementedException();
        }

        public Result<double> AverageTotalProcessingTimeByProducts()
        {
            throw new NotImplementedException();
        }

        public Result<double> AverageTotalProcessingTimeInAMonthByProducts(string month, string productName)
        {
            throw new NotImplementedException();
        }

        public Result<double> TotalProcessingTimeBySpesificProducts(string productName)
        {
            throw new NotImplementedException();
        }

        public Result<double> AverageTotalProcessingTimeBySpesificProducts(string productName)
        {
            throw new NotImplementedException();
        }
        //Aylık üretkenlik

        public Result<double> UtilizationRateFormula(string name)
        {
            // FORMULA : Total Billiable Hours / Total Hours Available
            //var beginHour = 20;
            //var duration = 10;
            var todayDate = DateTime.Now;
            var result = new Result<double>();
            //var endHour = DateTime.Today.AddHours(beginHour + duration).Hour;
            ////var results = dates.Where(x => beginHour < endHour
            ////                  ? (beginHour <= x.Hour && x.Hour <= endHour)
            ////                  : (beginHour <= x.Hour || x.Hour <= endHour));
            //var entities = AccountService.GetAll();
            //var filteredEntities = entities.Result.Data.Select(x => x).Where(x => x.Name == name).ToArray();
            //var billiableHours = filteredEntities.Select(x => x.Billings.Select(x => x.CreateDate).Where(x => beginHour < endHour
            //                                                                  ? (beginHour <= x.Hour && x.Hour <= endHour)
            //                                                                  : (beginHour <= x.Hour || x.Hour <=endHour)));

            //var totalAvailableHours = filteredEntities.Where(x => beginHour < endHour
            //                                                                  ? (beginHour <= x.CreateDate.Hour && x.CreateDate.Hour <= endHour)
            //                                                                  : (beginHour <= x.CreateDate.Hour || x.CreateDate.Hour <= endHour));
            var entities = AccountService.GetAll();
            var filteredByName = entities.Result.Data.Where(x => x.Name.Trim().ToLower() == name.Trim().ToLower()).Select(x => x.CreateDate).Single();
            var dt = todayDate - filteredByName;
            var ht = dt.TotalHours;
            var dtt = dt.TotalHours - 320;
            
            //Buraya log bağlanıp hesaplanacak
            var utilizitaionFormula = dtt / ht;

            if (utilizitaionFormula > 0)
            {
                result.Data = utilizitaionFormula;
            }
            else
            {
                result.Data = 0;
            }
            return result;
        }

        public Result<double> CapacityUtilizationRate()
        {
            throw new NotImplementedException();
        }
        //Klasik Stok yönetimi için ABC analizi
        //Yüzdelik dağılımları A : %70, B : %20-25, C : %10-5
        public Result<Dictionary<string, List<ProductDto>>> ABCAnalyze()
        {
            var result = new Result<Dictionary<string, List<ProductDto>>>();
            var entities = ProductService.GetAllProduct();
            var sortedEntities = entities.Result.Data.Select(x => x).OrderByDescending(x => x.Price).ToList();
            var totalValue = sortedEntities.Sum(x => x.Price);
            //Kümülatif
            var categoryA = totalValue * 0.7m;
            var categoryB = totalValue * 0.9m;

            var aProducts = sortedEntities.TakeWhile(x => x.Price >= categoryA).ToList();

            var bProducts = sortedEntities.SkipWhile(x => x.Price >= categoryA).TakeWhile(x =>x.Price >= categoryB).ToList();

            var cProducts = sortedEntities.SkipWhile(x => x.Price >= categoryB).ToList();

            if (aProducts != null && bProducts != null)
            {
                result.Data.Add("A Kategorisi", aProducts);
                result.Data.Add("B Kategorisi", bProducts);
                result.Data.Add("C Kategorisi", cProducts);

            }
            else
            {
                throw new Exception("Kategorileri oluştururacak kadar ürün yoktur");
            }
            return result;
        }

        public Result<double> TargetUtilization()
        {
            throw new NotImplementedException();
        }

        public Result<double> ProductsPriceMean()
        {
            var list = new Result<double>();
            var entities = ProductService.GetAllProduct();
            var filteredEntities = entities.Result.Data.Select(x => x.Price).ToList();
            var mean = filteredEntities.Sum() / filteredEntities.Count;
            if (mean > 0 && mean != 0)
            {
                list.Data = mean;
            }
            else
            {
                list.Data = 0;
            }
            return list;
        }

        public Result<double> BillingPriceMean()
        {
            var list = new Result<double>();
            var entities = BillingService.GetAllBilling();
            var filteredEntities = entities.Result.Data.Select(x => x.Product.Price).ToList();
            var mean = filteredEntities.Sum() / filteredEntities.Count;
            if (mean > 0 && mean != 0)
            {
                list.Data = mean;
            }
            else
            {
                list.Data = 0;
            }
            return list;

        }

        public Result<double> MeanDemandBillings()
        {
            throw new NotImplementedException();
        }
    }
}
