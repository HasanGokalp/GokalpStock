using GokalpStock.Application.Concrete.Models.Dtos;

namespace GokalpStock.Application.Concrete.Models.RequestModels.Accounts
{
    public class CreateAccountRM
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public AuthorityDto Authority { get; set; } = AuthorityDto.Employee;
        public StatusStrDto Status { get; set; }
    }
}
