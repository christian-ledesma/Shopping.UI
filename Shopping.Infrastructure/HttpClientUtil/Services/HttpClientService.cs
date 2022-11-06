using Newtonsoft.Json;
using Shopping.Infrastructure.HttpClientUtil.Entities;
using Shopping.Infrastructure.HttpClientUtil.Interfaces;
using System.Net;

namespace Shopping.Infrastructure.HttpClientUtil.Services
{
    public class HttpClientService : IHttpClientService
    {
        public async Task<HttpResponseMessage> Delete(HttpClientConfig config)
        {
            var client = new HttpClient();

            if (!config.IsLocalhost)
            {
                var httpClientHandler = new HttpClientHandler
                {
                    Proxy = new WebProxy(config.ProxyAddress, true),
                    UseProxy = true,
                };
                client = new HttpClient(httpClientHandler);
            }

            client.Timeout = TimeSpan.FromMinutes(config.HttpClientTimeout);

            HttpRequestMessage requestMessage = new();

            if (config.Headers != null && config.Headers.Count > 0)
            {
                foreach (KeyValuePair<string, string> item in config.Headers)
                {
                    requestMessage.Content.Headers.Add(item.Key, item.Value);
                }
            }

            return await client.DeleteAsync(config.URL);
        }

        public async Task<HttpResponseMessage> Get(HttpClientConfig config)
        {
            var client = new HttpClient();

            if (!config.IsLocalhost)
            {
                var httpClientHandler = new HttpClientHandler
                {
                    Proxy = new WebProxy(config.ProxyAddress, true),
                    UseProxy = true,
                };
                client = new HttpClient(httpClientHandler);
            }

            client.Timeout = TimeSpan.FromMinutes(config.HttpClientTimeout);

            HttpRequestMessage requestMessage = new();

            if (config.Headers != null && config.Headers.Count > 0)
            {
                foreach (KeyValuePair<string, string> item in config.Headers)
                {
                    requestMessage.Content.Headers.Add(item.Key, item.Value);
                }
            }

            return await client.GetAsync(config.URL);
        }

        public async Task<HttpResponseMessage> Post(HttpClientConfig config, object payload)
        {
            HttpClient client = new();

            if (!config.IsLocalhost)
            {
                var httpClientHandler = new HttpClientHandler
                {
                    Proxy = new WebProxy(config.ProxyAddress, true),
                    UseProxy = true,
                };
                client = new HttpClient(httpClientHandler);
            }

            client.Timeout = TimeSpan.FromMinutes(config.HttpClientTimeout);
            HttpRequestMessage requestMessage = new();

            if (config.Headers != null && config.Headers.Count > 0)
            {
                foreach (KeyValuePair<string, string> item in config.Headers)
                {
                    requestMessage.Content.Headers.Add(item.Key, item.Value);
                }
            }

            var stringPayload = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(stringPayload, config.Enconding, "application/json");

            return await client.PostAsync(config.URL, httpContent); ;
        }

        public async Task<HttpResponseMessage> Put(HttpClientConfig config, object payload)
        {
            HttpClient client = new();

            if (!config.IsLocalhost)
            {
                var httpClientHandler = new HttpClientHandler
                {
                    Proxy = new WebProxy(config.ProxyAddress, true),
                    UseProxy = true,
                };
                client = new HttpClient(httpClientHandler);
            }

            client.Timeout = TimeSpan.FromMinutes(config.HttpClientTimeout);
            HttpRequestMessage requestMessage = new();

            if (config.Headers != null && config.Headers.Count > 0)
            {
                foreach (KeyValuePair<string, string> item in config.Headers)
                {
                    requestMessage.Content.Headers.Add(item.Key, item.Value);
                }
            }

            var stringPayload = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(stringPayload, config.Enconding, "application/json");

            return await client.PutAsync(config.URL, httpContent);
        }
    }
}
