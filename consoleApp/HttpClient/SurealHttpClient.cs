﻿namespace Sureal.Auth.Common.HttpClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    public sealed class SurealHttpClient : IHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SurealHttpClient> logger;

        public SurealHttpClient(HttpClient httpClient, ILogger<SurealHttpClient> logger)
        {
            _httpClient = httpClient;
            this.logger = logger;
        }

        public async Task<HttpResponseMessage> PostAsync(string url, FormUrlEncodedContent content)
        {
            using (_httpClient)
            {
                var result = await _httpClient.PostAsync(url, content);
                return result;
            }
        }

        public async Task<HttpResponseMessage> PutAsync(string url, JsonEncodedContent content)
        {
            using (_httpClient)
            {
                var result = await _httpClient.PutAsync(url, content);
                return result;
            }
        }

        public AuthenticationHeaderValue GetAuthorizationHeaders()
        {
            return _httpClient.DefaultRequestHeaders.Authorization;
        }

        public void SetAuthorizationHeaders(string key, string value)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(key, value);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            using (_httpClient)
            {
                logger.LogInformation("Url = {0}", url);
                var newUri = new Uri(url, UriKind.Absolute);
                var result = await _httpClient.GetAsync(newUri);
                var content = await result.Content.ReadAsStringAsync();
                logger.LogInformation("Result = {0} \n {1}", result.StatusCode, content);
                return result;
            }
        }
    }
}