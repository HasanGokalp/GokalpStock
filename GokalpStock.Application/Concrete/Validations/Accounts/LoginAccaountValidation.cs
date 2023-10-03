using FluentValidation;
using GokalpStock.Application.Concrete.Models.RequestModels.Accounts;

namespace GokalpStock.Application.Concrete.Validations.Accounts
{
    public class LoginAccaountValidation : AbstractValidator<LoginAccountRM>
    {
        public LoginAccaountValidation()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");

        }
    }
}
