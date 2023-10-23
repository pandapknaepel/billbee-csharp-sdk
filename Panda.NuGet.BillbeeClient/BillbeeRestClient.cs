using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Json;
using Panda.NuGet.BillbeeClient.Configs;
using Panda.NuGet.BillbeeClient.Exceptions;

namespace Panda.NuGet.BillbeeClient;

public interface IBillbeeRestClient
{
    Task<HttpStatusCode> GetAsync(string resource);
    Task<T> GetAsync<T>(string resource, NameValueCollection? parameter = null) where T : new();
    Task<TResponse> PutAsync<TResponse, TRequest>(string resource, TRequest request);
    Task PutAsync<TRequest>(string resource, TRequest request);
    Task<TResponse> PatchAsync<TResponse, TRequest>(string resource, TRequest request);
    Task<TResponse> PostAsync<TResponse, TRequest>(string resource, TRequest request);
    Task PostAsync<TRequest>(string resource, TRequest request);
    Task<TResponse> PostAsync<TResponse>(string resource);
    Task DeleteAsync(string resource, NameValueCollection? parameter = null);
}

internal class BillbeeRestClient : IBillbeeRestClient
{
    private readonly BillbeeApiConfig _config;
    private readonly HttpClient _httpClient;

    public BillbeeRestClient(BillbeeApiConfig billbeeApiConfig, HttpClient httpClient)
    {
        _config = billbeeApiConfig;
        _httpClient = httpClient;
    }

    public async Task<HttpStatusCode> GetAsync(string resource)
    {
        var response = await _httpClient.GetAsync(resource);
        return response.StatusCode;
    }

    public async Task<T> GetAsync<T>(string resource, NameValueCollection? parameter = null) where T : new()
    {
        var path = GetBasePath(resource);
        if (parameter != null)
        {
            path += "?" + NameValueCollectionToQueryString(parameter);
        }
        var request = new HttpRequestMessage(HttpMethod.Get, path);
        var response = await SendRequestWithRetryAsync(request);
        return (await response.Content.ReadFromJsonAsync<T>())!;
    }

    public async Task<TResponse> PutAsync<TResponse, TRequest>(string resource, TRequest request)
    {
        var path = GetBasePath(resource);
        var requestMessage = new HttpRequestMessage(HttpMethod.Put, path)
        {
            Content = JsonContent.Create(request)
        };
        var response = await SendRequestWithRetryAsync(requestMessage);
        return (await response.Content.ReadFromJsonAsync<TResponse>())!;
    }

    public async Task PutAsync<TRequest>(string resource, TRequest request)
    {
        var path = GetBasePath(resource);
        var requestMessage = new HttpRequestMessage(HttpMethod.Put, path)
        {
            Content = JsonContent.Create(request)
        };
        _ = await SendRequestWithRetryAsync(requestMessage);
    }

    public async Task<TResponse> PatchAsync<TResponse, TRequest>(string resource, TRequest request)
    {
        var path = GetBasePath(resource);
        var requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), path)
        {
            Content = JsonContent.Create(request)
        };
        var response = await SendRequestWithRetryAsync(requestMessage);
        return (await response.Content.ReadFromJsonAsync<TResponse>())!;
    }
        
    public async Task<TResponse> PostAsync<TResponse, TRequest>(string resource, TRequest request)
    {
        var path = GetBasePath(resource);
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, path)
        {
            Content = JsonContent.Create(request)
        };
        var response = await SendRequestWithRetryAsync(requestMessage);
        return (await response.Content.ReadFromJsonAsync<TResponse>())!;
    }

    public async Task PostAsync<TRequest>(string resource, TRequest request)
    {
        var path = GetBasePath(resource);
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, path)
        {
            Content = JsonContent.Create(request)
        };
        _ = await SendRequestWithRetryAsync(requestMessage);
    }

    public async Task<TResponse> PostAsync<TResponse>(string resource)
    {
        var path = GetBasePath(resource);
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, path);
        var response = await SendRequestWithRetryAsync(requestMessage);
        return (await response.Content.ReadFromJsonAsync<TResponse>())!;
    }

    public async Task DeleteAsync(string resource, NameValueCollection? parameter = null)
    {
        var path = GetBasePath(resource);
        if (parameter != null)
        {
            path += "?" + NameValueCollectionToQueryString(parameter);
        }
        var request = new HttpRequestMessage(HttpMethod.Delete, path);
        _ = await SendRequestWithRetryAsync(request);
    }
    
    private string GetBasePath(string resource)
    {
        return $"{_config.BaseUrl}/{resource}";
    }

    private static string NameValueCollectionToQueryString(NameValueCollection nameValueCollection)
    {
        return string.Join("&", nameValueCollection.AllKeys
            .Where(key => key != default)
            .Select(key => $"{Uri.EscapeDataString(key!)}={Uri.EscapeDataString(nameValueCollection[key]!)}"));
    }
    
    private async Task<HttpResponseMessage> SendRequestWithRetryAsync(HttpRequestMessage requestMessage)
    {
        for (var retry = 0; retry <= 3; retry++)
        {
            var response = await _httpClient.SendAsync(requestMessage);

            if (response.StatusCode != HttpStatusCode.TooManyRequests || retry == 3)
            {
                await HandleResponseAsync($"{requestMessage.Method} {requestMessage.RequestUri}", response);
                return response;
            }

            await Task.Delay(TimeSpan.FromSeconds(10));
        }

        throw new InvalidOperationException("Max retries reached.");
    }


    private static async Task HandleResponseAsync(string caller, HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            return;
        }
        
        var content = await response.Content.ReadAsStringAsync();
        throw new BillbeeHttpException(caller, response.StatusCode, content);
    }
}