using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace Tests.Extensions
{
    public static class HttpResponseMessageExtension
    {
        public static T GeContentAs<T>(this HttpResponseMessage message)
        {
            var contentString = message.Content.ReadAsStringAsync().Result;
            var content = JsonConvert.DeserializeObject<T>(contentString);
            return content;
        }
    }
}
