using FluentValidation;
using GokalpStock.Application.Concrete.Models.RequestModels.Accounts;

namespace GokalpStock.Application.Concrete.Validations.Accounts
{
    public class DeleteAccountValidation : AbstractValidator<DeleteAccountRM>
    {
        public DeleteAccountValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id boş olamaz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş olamaz");

        }
    }
}
