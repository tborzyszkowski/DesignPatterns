using System.Net;
using System.Threading.Tasks;
using CarsCms.ApiConsumer.Interfaces;
using CarsCms.ApiConsumer.Model;

namespace CarsCms.ApiConsumer.Adapter
{
    public class EmailAdapter : IEmailAdapter
    {
        private readonly IEmailClient _emailClient;
        public EmailAdapter(IEmailClient emailClient)
        {
            _emailClient = emailClient;
        }

        public async Task<HttpStatusCode> SendEmail(EmailApiModel model)
        {
            model.To = model.To;
            model.Topic = model.Topic;
            model.Body = "jakas tresc";
            var result = await _emailClient.Post(model);
            return result;
        }
    }
}