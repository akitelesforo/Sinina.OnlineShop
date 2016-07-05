using Microsoft.AspNet.Identity;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System;

namespace Sinina.OnlineShop.API.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            var mailMessage = new MailMessage(Convert.ToString(ConfigurationManager.AppSettings["SmtpFromAddress"]), message.Destination);
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Body;

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Host = Convert.ToString(ConfigurationManager.AppSettings["SmtpServerName"]);
                smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);
                smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SmtpSsl"]); ;
                smtpClient.Timeout = 10000;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(Convert.ToString(ConfigurationManager.AppSettings["SmtpUserName"]),
                    Convert.ToString(ConfigurationManager.AppSettings["SmtpPassword"]));
                
                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}