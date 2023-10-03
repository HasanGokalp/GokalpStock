using FluentValidation;
using GokalpStock.Application.Concrete.Models.RequestModels.Billings;

namespace GokalpStock.Application.Concrete.Validations.Billings
{
    public class DeleteBillingsValidation : AbstractValidator<DeleteBillingRM>
    {
        public DeleteBillingsValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id boş olamaz");
            

        }
    }
}
