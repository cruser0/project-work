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
            string host = _appSettings["HMailServer:SmtpHost"];
            int port = int.Parse(_appSettings["HMailServer:Port"]);
            string user = _appSettings["HMailServer:SmtpUser"];
            string password = _appSettings["HMailServer:SmtpPass"];

            string formattedBody = email.Body
                .Replace("\r\n\r\n", "<br><br>")
                .Replace("\n\n", "<br><br>")
                .Replace("\r\n", "<br>")
                .Replace("\n", "<br>");

            string htmlContent = $"{formattedBody}<br><br><a href=\"{email.Link}\">Visualizza dettagli</a>";

            using (var smtpClient = new SmtpClient(host, port))
            using (var mailMessage = new MailMessage
            {
                From = new MailAddress(user),
                Subject = email.Subject,
                Body = htmlContent,
                IsBodyHtml = true
            })
            {
                smtpClient.Credentials = new NetworkCredential(user, password);
                smtpClient.EnableSsl = false;

                mailMessage.To.Add(email.To);

                using (var stream = new MemoryStream(pdfBytes))
                {
                    var attachment = new Attachment(stream, email.FileName, MediaTypeNames.Application.Pdf);
                    mailMessage.Attachments.Add(attachment);

                    try
                    {
                        smtpClient.Send(mailMessage);
                        smtpClient.Dispose();
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
