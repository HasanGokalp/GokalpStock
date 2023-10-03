using GokalpStock.Domain.Abstract;
using GokalpStock.Domain.Enum;

namespace GokalpStock.Domain.Concrete
{
    public class Account : AuditableEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        //public IEnumerable<Authority> Authorities { get; set; }
        public Authority Authority { get; set; }
        public IEnumerable<Billing>? Billings { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}
