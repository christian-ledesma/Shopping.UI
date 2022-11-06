using System.Text;

namespace Shopping.Infrastructure.HttpClientUtil.Entities
{
    public class HttpClientConfig
    {
        public string URL { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string ProxyAddress { get; set; }
        public bool IsLocalhost { get; set; }
        public string Content { get; set; }
        public Encoding Enconding { get; set; }
        public string MediaType { get; set; }
        public int HttpClientTimeout { get; set; }
    }
}
