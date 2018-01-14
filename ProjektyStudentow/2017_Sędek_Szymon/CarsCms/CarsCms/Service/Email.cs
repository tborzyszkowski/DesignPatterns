using System;
using CarsCms.ApiConsumer.Model;
using CarsCms.Enums;

namespace CarsCms.Service
{
    public class Email
    {
        public EmailApiModel CreateEmailModel(EmailType emailType)
        {
            var email = new EmailApiModel();
            email.To = "sendTO";
            switch (emailType)
            {
                case EmailType.UserAuth:
                    email.Topic = "User zalogowany";
                    break;
                case EmailType.OtherUser:
                    email.Topic = "User niezalogowany";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(emailType), emailType, null);
            }
            return email;
        }
    }
}