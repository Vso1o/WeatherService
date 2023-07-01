using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Business.Utils.Interfaces
{
    /// <summary>
    /// Interface for class which helps to perform Http requsets. Note that there is no authentication in this app
    /// </summary>
    public interface IHttpUtil
    {
        Task<HttpResponseMessage> GetAsync(string url);

        Task<HttpResponseMessage> PostJsonAsync<T>(string url, T postData);

        Task<HttpResponseMessage> PutJsonAsync<T>(string url, T postData);

        Task<HttpResponseMessage> DeleteAsync(string url);

        Task<HttpResponseMessage> PatchAsync(string url);

        bool IsSuccessfulStatusCode(HttpResponseMessage httpResponse);
    }
}
