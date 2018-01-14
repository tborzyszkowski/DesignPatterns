using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CarsCms.ApiConsumer.Interfaces
{
    public interface IClientAbstract <T> where T : class
    {
        void SetUrl(string url);
        Task<List<T>> GetAll();
        Task<HttpStatusCode> Post(T model);
    }
}
