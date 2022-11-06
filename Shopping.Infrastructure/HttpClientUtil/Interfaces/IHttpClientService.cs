using Shopping.Infrastructure.HttpClientUtil.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.HttpClientUtil.Interfaces
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> Delete(HttpClientConfig config);
        Task<HttpResponseMessage> Get(HttpClientConfig config);
        Task<HttpResponseMessage> Post(HttpClientConfig config, object payload);
        Task<HttpResponseMessage> Put(HttpClientConfig config, object payload);
    }
}
