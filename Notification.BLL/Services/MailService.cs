using Notification.Entities.Models;
using Notification.BLL.Settings;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MailKit;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Notification.DAL;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Notification.BLL.Services
{
    public class MailService : IMailService
    {
        private IEmailRepository _emailRepository;
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings, IEmailRepository emailRepository)
        {
            _mailSettings = mailSettings.Value;
            _emailRepository = emailRepository;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.To));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            //if (mailRequest.Attachments != null)
            //{
            //    byte[] fileBytes;
            //    foreach (var file in mailRequest.Attachments)
            //    {
            //        if (file.Length > 0)
            //        {
            //            using (var ms = new MemoryStream())
            //            {
            //                file.CopyTo(ms);
            //                fileBytes = ms.ToArray();
            //            }
            //            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
            //        }
            //    }
            //}
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await _emailRepository.SaveEmail(mailRequest);
            var res = await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

       
        public async Task<IEnumerable<MailRequest>> GetMail()
        {
            return await _emailRepository.GetAllEmails();
            
           
        }

        //public async Task GetEmails()

        //public async Task SendWelcomeEmailAsync(WelcomeRequest request)
        //{
        //    string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\WelcomeTemplate.html";
        //    StreamReader str = new StreamReader(FilePath);
        //    string MailText = str.ReadToEnd();
        //    str.Close();
        //    MailText = MailText.Replace("[username]", request.UserName).Replace("[email]", request.ToEmail);
        //    var email = new MimeMessage();
        //    email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        //    email.To.Add(MailboxAddress.Parse(request.ToEmail));
        //    email.Subject = $"Welcome {request.UserName}";
        //    var builder = new BodyBuilder();
        //    builder.HtmlBody = MailText;
        //    email.Body = builder.ToMessageBody();
        //    using var smtp = new SmtpClient();
        //    smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        //    smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        //    await smtp.SendAsync(email);
        //    smtp.Disconnect(true);
        //}
    }
}