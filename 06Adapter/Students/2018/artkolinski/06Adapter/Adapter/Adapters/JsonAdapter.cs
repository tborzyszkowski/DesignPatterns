using Newtonsoft.Json;

namespace Adapter.Adapters
{
    public class JsonAdapter
    {
        public string CreateJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}