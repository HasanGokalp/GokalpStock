namespace GokalpStock.Application.Concrete.Models.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        //public IEnumerable<Authority> Authorities { get; set; }
        public AuthorityDto Authority { get; set; }
        public IEnumerable<BillingDto>? Billings { get; set; }
        public IEnumerable<ProductDto>? Products { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
