using ProjetPFE.EmailService.EmailEntities;

namespace ProjetPFE.EmailService.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);

    }
}
