using Entity_Validator.Entity.DTO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace API.Models.Services
{
    public interface IEmailService
    {
        Task<EmailDTO> SendEmail(EmailDTO email);
    }
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _appSettings;


        public EmailService(IConfiguration Appsettings)
        {
            _appSettings = Appsettings;
        }

        public async Task<EmailDTO> SendEmail(EmailDTO email)
        {
            byte[] pdfBytes = Convert.FromBase64String(email.PdfContent);

            using (var smtpClient = new SmtpClient(_appSettings["HMailServer:SmtpHost"], int.Parse(_appSettings["HMailServer:Port"])))
            using (var mailMessage = new MailMessage
            {
                From = new MailAddress(_appSettings["HMailServer:SmtpUser"]),
                Subject = email.Subject,
                Body = email.Body,
                IsBodyHtml = true
            })
            {
                smtpClient.Credentials = new NetworkCredential(_appSettings["HMailServer:SmtpUser"], _appSettings["HMailServer:SmtpPass"]);
                smtpClient.EnableSsl = false;

                mailMessage.To.Add(email.To);

                using (var stream = new MemoryStream(pdfBytes))
                {
                    var attachment = new Attachment(stream, email.FileName, MediaTypeNames.Application.Pdf);
                    mailMessage.Attachments.Add(attachment);

                    try
                    {
                        smtpClient.Send(mailMessage);
                        return email;
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }

    }

}
