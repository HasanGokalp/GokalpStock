using GokalpStock.Application.Concrete.Models.EMail;

namespace GokalpStock.Application.Abstract.Service
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
