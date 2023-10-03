using GokalpStock.Application.Concrete.Models.Dtos;

namespace GokalpStock.Application.Concrete.Models.RequestModels.Products
{
    public class CreateProductRM
    {
        public int BillingId { get; set; }
        public int AccountId { get; set; }
        public AccountDto Account { get; set; }
        public BillingDto Billing { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int InStock { get; set; }
    }
}
