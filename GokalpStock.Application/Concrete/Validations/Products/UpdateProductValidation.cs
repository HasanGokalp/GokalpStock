using FluentValidation;
using GokalpStock.Application.Concrete.Models.RequestModels.Products;

namespace GokalpStock.Application.Concrete.Validations.Products
{
    public class UpdateProductValidation : AbstractValidator<UpdateProductRM>
    {
        public UpdateProductValidation()
        {
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün bilgileri boş olamaz");
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün id bilgisi boş olamaz");
            RuleFor(x => x.InStock).NotEmpty().WithMessage(" bilgisi boş olamaz");
            RuleFor(x => x.Billing).NotNull().WithMessage("Form boş bırakılamaz boş olamaz");
            RuleFor(x => x.Account).NotEmpty().WithMessage("Hesap bilgileri boş olamaz");
            RuleFor(x => x.AccountId).NotEmpty().WithMessage("Kullanıcı bilgileri boş olamaz");
            RuleFor(x => x.BillingId).NotEmpty().WithMessage("Fatura bilgileri boş olamaz");
        }
    }
}
