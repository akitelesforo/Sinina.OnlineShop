using Microsoft.AspNet.Identity;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Sinina.OnlineShop.API.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            var mailMessage = new MailMessage();
            mailMessage.To.Add(message.Destination);

            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Body;

            using (var smtpClient = new SmtpClient())
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}