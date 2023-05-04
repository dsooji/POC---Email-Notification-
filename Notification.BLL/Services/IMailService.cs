using Microsoft.AspNetCore.Mvc;
using Notification.DAL;
using Notification.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.BLL.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        
        Task<IEnumerable<MailRequest>> GetMail();
        
    }
}
