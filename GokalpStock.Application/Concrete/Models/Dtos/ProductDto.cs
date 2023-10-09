namespace GokalpStock.Application.Concrete.Models.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }
        public int BillingId { get; set; }
        public int AccountId { get; set; }
        public AccountDto Account { get; set; }
        public BillingDto Billing { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int InStock { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
