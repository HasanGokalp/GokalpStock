using GokalpStock.Application.Concrete.Models.Dtos;

namespace GokalpStock.Application.Concrete.Models.RequestModels.Billings
{
    public class UpdateBillingRM
    {
        public bool? IsDeleted { get; set; }
        public int AccountId { get; set; }
        public int ProductId { get; set; }
        public AccountDto Account { get; set; }
        public ProductDto Product { get; set; }
        public bool IsItConfirm { get; set; }
        public StatusStrDto Status { get; set; }
    }
}
