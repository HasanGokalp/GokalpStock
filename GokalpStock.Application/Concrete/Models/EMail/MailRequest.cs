using GokalpStock.Application.Abstract.Models.EMail;
using Microsoft.AspNetCore.Http;

namespace GokalpStock.Application.Concrete.Models.EMail
{
    public class MailRequest : IMailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
