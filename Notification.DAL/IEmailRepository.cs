using Notification.Entities.Models;

namespace Notification.DAL
{
    public interface IEmailRepository
    {
        Task<bool> SaveEmail(MailRequest mailRequest);

        Task<IEnumerable<MailRequest>> GetAllEmails(); 
        //IEnumerable<MailRequest> GetAll();

    }
}