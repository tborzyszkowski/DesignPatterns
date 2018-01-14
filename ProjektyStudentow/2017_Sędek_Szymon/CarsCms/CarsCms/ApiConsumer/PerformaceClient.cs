using CarsCms.ApiConsumer.Interfaces;
using CarsCms.ApiConsumer.Model;

namespace CarsCms.ApiConsumer
{
    public class PerformaceClient : ClientAbstract<Performance>, IPerformanceClient
    {
        public PerformaceClient()
        {
            SetUrl("http://localhost:53782/api/Performances");
        }
    }
}