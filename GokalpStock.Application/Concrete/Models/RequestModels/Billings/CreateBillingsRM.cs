using GokalpStock.Application.Concrete.Models.Dtos;

namespace GokalpStock.Application.Concrete.Models.RequestModels.Billings
{
    public class CreateBillingsRM
    {
        public AccountDto Account { get; set; }
        public ProductDto Product { get; set; }
        public bool IsItConfirm { get; set; } = false;
        public StatusStrDto Status { get; set; } = StatusStrDto.Teklif;
    }
}
