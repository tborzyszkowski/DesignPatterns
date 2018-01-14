using CarsCms.ApiConsumer.Interfaces;
using CarsCms.ApiConsumer.Model;

namespace CarsCms.ApiConsumer
{
    public class EmailClient : ClientAbstract<EmailApiModel>, IEmailClient
    {
        public EmailClient()
        {
            SetUrl("http://localhost:53782/api/Email");
        }


    }
}