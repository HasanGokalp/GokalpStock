using GokalpStock.Domain.Abstract;
using GokalpStock.Domain.Enum;

namespace GokalpStock.Domain.Concrete
{
    public class Billing : AuditableEntity
    {
        public int AccountId { get; set; }
        public int ProductId { get; set; }
        public Account Account { get; set; }
        public Product Product { get; set; }
        public bool IsItConfirm { get; set; }
        public StatusStr Status { get; set; }


    }
}
