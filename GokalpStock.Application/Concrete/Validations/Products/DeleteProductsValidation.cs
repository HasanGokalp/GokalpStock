using FluentValidation;
using GokalpStock.Application.Concrete.Models.RequestModels.Products;

namespace GokalpStock.Application.Concrete.Validations.Products
{
    public class DeleteProductsValidation : AbstractValidator<DeleteProductRM>
    {
        public DeleteProductsValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id boş olamaz");
            

        }
    }
}
