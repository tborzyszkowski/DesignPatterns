using System.Net;
using System.Net.Mail;
using CarCmsWebApi.Models;

namespace CarCmsWebApi.Service
{
    public class EmailService
    {
        public void SendEmail(EmailApiModel mailModel)
        {
            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials =
                    new NetworkCredential("login", "pass")
            };
            var mailMessage = new MailMessage
            {
                Sender = new MailAddress("login"),
                From = new MailAddress("login"),
                To = { mailModel.To },
                Body = mailModel.Body,
                Subject = mailModel.Topic,
                IsBodyHtml = true
            };

            smtpClient.Send(mailMessage);
        }
    }
}