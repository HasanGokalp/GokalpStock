using GokalpStock.Domain.Abstract;

namespace GokalpStock.Domain.Concrete
{
    public class Product : AuditableEntity
    {
        public int BillingId { get; set; }
        public int AccountId { get; set; }
        public Account? Account { get; set; }
        public Billing? Billing { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int InStock { get; set; }
    }
}
