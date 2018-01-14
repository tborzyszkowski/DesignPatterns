using System.Net;
using System.Threading.Tasks;
using CarsCms.ApiConsumer.Model;

namespace CarsCms.ApiConsumer.Interfaces
{
    public interface IEmailAdapter
    {
        Task<HttpStatusCode> SendEmail(EmailApiModel model);
    }
}