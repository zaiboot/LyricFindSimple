namespace Sureal.Auth.Common.HttpClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public interface IHttpClient : IDisposable
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, FormUrlEncodedContent content);

        Task<HttpResponseMessage> PutAsync(string url, JsonEncodedContent content);

        AuthenticationHeaderValue GetAuthorizationHeaders();

        void SetAuthorizationHeaders(string key, string value);
    }
}
