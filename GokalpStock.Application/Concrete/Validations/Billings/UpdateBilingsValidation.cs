using FluentValidation;
using GokalpStock.Application.Concrete.Models.RequestModels.Billings;

namespace GokalpStock.Application.Concrete.Validations.Billings
{
    public class UpdateBilingsValidation : AbstractValidator<UpdateBillingRM>
    {
        public UpdateBilingsValidation()
        {
            RuleFor(x => x.Product).NotEmpty().WithMessage("Ürün bilgileri boş olamaz");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Ürün id bilgisi boş olamaz");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Yetki bilgisi boş olamaz");
            RuleFor(x => x.IsDeleted).NotNull().WithMessage("Bilgi boş bırakılamaz boş olamaz");
            RuleFor(x => x.Account).NotEmpty().WithMessage("Ürün bilgileri boş olamaz");
            RuleFor(x => x.AccountId).NotEmpty().WithMessage("Ürün bilgileri boş olamaz");
            


        }
    }
}
