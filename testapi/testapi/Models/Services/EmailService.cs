using System.Net;
using System.Net.Mail;

namespace API.Models.Services
{
    public interface IEmailService
    {
        Task<string> SendEmail(string to, string subject, string body);
    }
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _appSettings;


            public EmailService(IConfiguration Appsettings)
            {
                _appSettings = Appsettings;
            }


        public  async Task<string> SendEmail(string to, string subject, string body)
        {
            var smtpClient = new SmtpClient("localhost.com", 9000)
            {
                Credentials = new NetworkCredential("admin@localhost.com", "12345"),
                EnableSsl = false
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("admin@localhost.com"),
                Subject = "Test Email",
                Body = "Test from backend",
                IsBodyHtml = true
            };

            mailMessage.To.Add("server@localhost.com"); 


            try
            {
                smtpClient.Send(mailMessage);
                return "Email sent successfully!";
            }
            catch (Exception ex)
            {
                return $"Error sending email: {ex.Message}";
            }
        }
    }
        
}
