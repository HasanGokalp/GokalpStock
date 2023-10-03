using FluentValidation;
using GokalpStock.Application.Concrete.Models.RequestModels.Billings;

namespace GokalpStock.Application.Concrete.Validations.Billings
{
    public class CreateBillingsValidation : AbstractValidator<CreateBillingsRM>
    {
        public CreateBillingsValidation()
        {
            RuleFor(x => x.Account).NotEmpty().WithMessage("Hesap bilgileri boş olamaz");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Yetki bilgileri boş olamaz");
            RuleFor(x => x.Product).NotEmpty().WithMessage("Ürün bilgileri boş olamaz");
           


        }
    }
}
