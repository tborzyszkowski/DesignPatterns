using Newtonsoft.Json;

namespace ComputerProjects.Adapters
{
    public class JsonAdapter
    {
        public string CreateJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}