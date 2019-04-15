using System.Net.Http;
using System.Text;

namespace Tests.Helpers
{
    public class StringContentFactory
    {
        public Encoding Encoding { get; }
        public string MediaType { get; }

        public StringContentFactory(Encoding encoding, string mediaType)
        {
            Encoding = encoding;
            MediaType = mediaType;
        }

        public StringContent CreateStringContent(string content)
        {
            return new StringContent(content, Encoding.UTF8, "application/json");
        }
    }
}