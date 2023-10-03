using FluentValidation;
using GokalpStock.Application.Concrete.Models.RequestModels.Accounts;

namespace GokalpStock.Application.Concrete.Validations.Accounts
{
    public class CreateAccountValidation : AbstractValidator<CreateAccountRM>
    {
        public CreateAccountValidation()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).WithMessage("Girdiğiniz isim hatalı");
            RuleFor(x => x.Authority).NotEmpty().WithMessage("Yetki seçmelisiniz");
            RuleFor(x => x.Status).NotNull().WithMessage("Durumu boş olamaz");
            RuleFor(x => x.Email).NotEmpty().MinimumLength(5).WithMessage("Email boş olamaz veya minimum 5 karekter olabilir");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Şifre boş olamaz veya minimum 5 karakter içerebilir");
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(3).WithMessage("Kullanıcı adı boş olamaz veya minimum 3 karakter olabilir");
            
        }
    }
}
