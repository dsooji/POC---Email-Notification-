namespace Notification.Entities.Models
{
    public class MailRequest
    {
        public string To { get; set; }

        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        /*public List<IFormFile> Attachments { get; set; }*/  //IFormFile helps to  speed up the processing of uploading files//
    }
}
