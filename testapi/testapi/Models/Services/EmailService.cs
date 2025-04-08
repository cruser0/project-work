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
            var smtpClient = new SmtpClient(_appSettings["HMailServer:SmtpHost"], int.Parse(_appSettings["HMailServer:Port"]))
            {
                Credentials = new NetworkCredential(_appSettings["HMailServer:SmtpUser"], _appSettings["HMailServer:SmtpPass"]),
                EnableSsl = false
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_appSettings["HMailServer:SmtpUser"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(to); 


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
