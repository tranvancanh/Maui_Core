using MauiUI.AppConfigure;
using MauiUI.Models;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace MauiUI.Services
{
    public interface ICallApiService
    {
        Task<string> GetAsync(string action, Dictionary<string, string> queryParams = null, string baseUrl = null);
        Task<string> PostAsync(string action, string jsonData, string baseUrl = null);
    }

    public class CallApiService : ICallApiService
    {
        private readonly string _testUrl;
        private readonly string _productionUrl;

        IConfiguration _configuration;
        public CallApiService(IConfiguration configuration)
        {
            _configuration = configuration;
            var settings = configuration.GetRequiredSection("connectionUrl");
            var testUrl = settings.GetValue<string>("test");
            var productionUrl = settings.GetValue<string>("production");
            _testUrl = testUrl;
            _productionUrl = productionUrl;
        }

        public async Task<string> GetAsync(string action, Dictionary<string, string> queryParams = null, string baseUrl = null)
        {
            var urlString = await this.BuildUrlWithQueryStringUsingUriBuilder(baseUrl, action, queryParams);
            using (var httpClient = new HttpClient())
            {
                // Set default request headers
                httpClient.DefaultRequestHeaders.Add("User-Agent", "My-App");
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                // Make a request
                var response = await httpClient.GetAsync(urlString);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(content);
                }
            }

            return null;
        }

        public Task<string> PostAsync(string action, string jsonData, string baseUrl = null)
        {
            throw new NotImplementedException();
        }

        private async Task<string> BuildUrlWithQueryStringUsingUriBuilder(string baseUrl, string action, Dictionary<string, string> queryParams)
        {
            var urlString = string.Empty;
            // base url render
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                var settingTable = (await SqlLiteAccess<SettingTable>.GetAsync()).FirstOrDefault();
                if(settingTable == null)
                {
#if DEBUG
                    baseUrl = _testUrl;
#else
                    baseUrl = _productionUrl;
#endif
                }
                else
                {
                    baseUrl = settingTable.HandyApiUrl;
                }
            }
            else
            {
                urlString = baseUrl;
            }
            urlString = urlString + action;
            // parameter render
            if (queryParams != null)
            {
                var uriBuilder = new UriBuilder(urlString)
                {
                    Query = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"))
                };
                urlString = uriBuilder.Uri.AbsoluteUri;
            }
            return urlString;
        }
    }
}
