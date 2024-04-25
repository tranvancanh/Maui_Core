using MauiUI.AppConfigure;
using MauiUI.Extensions;
using MauiUI.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace MauiUI.Services
{
    public interface ICallApiService
    {
        Task<string> GetAsync(string action, Dictionary<string, string> queryParams = null, string baseUrl = null, CancellationToken cancellationToken = default);
        Task<string> PostAsync(string action, object postContent, string baseUrl = null, CancellationToken cancellationToken = default);
    }

    public class CallApiService : ICallApiService
    {
        private readonly string _testUrl;
        private readonly string _productionUrl;

        private readonly IConfiguration _configuration;
        public CallApiService(IConfiguration configuration)
        {
            _configuration = configuration;
            var settings = configuration.GetRequiredSection("connectionUrl");
            var testUrl = settings.GetValue<string>("test");
            var productionUrl = settings.GetValue<string>("production");
            _testUrl = testUrl;
            _productionUrl = productionUrl;
        }

        public async Task<string> GetAsync(string action, Dictionary<string, string> queryParams = null, string baseUrl = null, CancellationToken cancellationToken = default)
        {
            var urlString = await this.BuildUrlWithQueryStringUsingUriBuilder(baseUrl, action, queryParams);
            // Create an HttpClientHandler
            // // Create an instance of HttpClient
            HttpClientHandler insecureHandler = null;
            HttpClient httpClient = null;
#if DEBUG
            insecureHandler = GetInsecureHandler();
            httpClient = new HttpClient(insecureHandler);
#else
    httpClient = new HttpClient();
#endif
            try
            {
                // Set default request headers
                httpClient.AddRequestHeaders();

                // Make a GET request to an API endpoint
                var registrationResponse = await httpClient.GetAsync(urlString, cancellationToken);
                // Ensure the response is successful
                registrationResponse.EnsureSuccessStatusCode();
                // Output the response content
                var responseContent = await registrationResponse.Content.ReadAsStringAsync();
                Debug.WriteLine(responseContent);
                return responseContent;
            }
            catch( Exception ex)
            {
                // Handle other exceptions
                Debug.WriteLine($"Error Url: urlString {Environment.NewLine} Message :{0} ", ex.Message);
                throw;
            }
            finally
            {
                // Need to call dispose on the HttpClient and HttpClientHandler objects
                // when done using them, so the app doesn't leak resources
                insecureHandler?.Dispose();
                httpClient?.Dispose();
            }
        }

        public async Task<string> PostAsync(string action, object postContent, string baseUrl = null, CancellationToken cancellationToken = default)
        {
            // Create an HttpClientHandler
            // Create an HttpClient object
            HttpClientHandler insecureHandler = null;
            HttpClient httpClient = null;
#if DEBUG
            insecureHandler = GetInsecureHandler();
            httpClient = new HttpClient(insecureHandler);
#else
    httpClient = new HttpClient();
#endif
            try
            {
                // Set default request headers
                httpClient.AddRequestHeaders();

                // Make a request
                // Prepare the data to be sent in the request body
                var jsonData = JsonConvert.SerializeObject(postContent); // JSON data
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                // Make a GET request to an API endpoint
                var registrationResponse = await httpClient.PostAsync(baseUrl, content, cancellationToken);
                // Ensure the response is successful
                registrationResponse.EnsureSuccessStatusCode();
                // Output the response content
                var responseContent = await registrationResponse.Content.ReadAsStringAsync();
                return responseContent;
            }
            catch(Exception ex)
            {
                // Handle other exceptions
                Debug.WriteLine($"Error Url: urlString {Environment.NewLine} Message :{0} ", ex.Message);
                throw;
            }
            finally
            {
                // Need to call dispose on the HttpClient and HttpClientHandler objects
                // when done using them, so the app doesn't leak resources
                insecureHandler?.Dispose();
                httpClient?.Dispose();
            }
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
            urlString = baseUrl + action;
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

        public static HttpClientHandler GetInsecureHandler()
        {
            var handler = new HttpClientHandler();
            // Disabling SSL certificate validation (for testing purposes only, not recommended in production)
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            return handler;
        }


    }
}
