using Microsoft.AspNetCore.Mvc;
using Notification.BLL;
using Notification.Entities.Models;
using Notification.BLL.Services;
using Notification.DAL;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;


namespace Notification.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;



        public MailController(IMailService mailService)
        {
            this._mailService = mailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMail(MailRequest request)
        {
            try
            {
                await _mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmails()
        {
            return Ok(await _mailService.GetMail());

            
        }







        //[HttpPost("welcome")]
        //public async Task<IActionResult> SendWelcomeMail([FromBody] WelcomeRequest request)
        //{
        //    try
        //    {
        //        await _mailService.SendWelcomeEmailAsync(request);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}
    }
}
