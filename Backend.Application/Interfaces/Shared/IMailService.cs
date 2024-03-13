using Backend.Application.DTOs.Mail;
using System.Threading.Tasks;

namespace Backend.Application.Interfaces.Shared
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}