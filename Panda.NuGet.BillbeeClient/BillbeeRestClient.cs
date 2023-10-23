using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Json;
using Panda.NuGet.BillbeeClient.Configs;
using Panda.NuGet.BillbeeClient.Exceptions;

namespace Panda.NuGet.BillbeeClient;

internal interface IBillbeeRestClient
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
        var response = await _httpClient.SendAsync(request);
        await HandleResponseAsync($"GET {path}", response);
        return (await response.Content.ReadFromJsonAsync<T>())!;
    }

    public async Task<TResponse> PutAsync<TResponse, TRequest>(string resource, TRequest request)
    {
        var path = GetBasePath(resource);
        var response = await _httpClient.PutAsJsonAsync(path, request);
        await HandleResponseAsync($"PUT {path}", response);
        return (await response.Content.ReadFromJsonAsync<TResponse>())!;
    }

    public async Task PutAsync<TRequest>(string resource, TRequest request)
    {
        var path = GetBasePath(resource);
        var response = await _httpClient.PutAsJsonAsync(path, request);
        await HandleResponseAsync($"PUT {path}", response);
    }

    public async Task<TResponse> PatchAsync<TResponse, TRequest>(string resource, TRequest request)
    {
        var path = GetBasePath(resource);
        var response = await _httpClient.PatchAsJsonAsync(path, request);
        await HandleResponseAsync($"PATCH {path}", response);
        return (await response.Content.ReadFromJsonAsync<TResponse>())!;
    }
        
    public async Task<TResponse> PostAsync<TResponse, TRequest>(string resource, TRequest request)
    {
        var path = GetBasePath(resource);
        var response = await _httpClient.PostAsJsonAsync(path, request);
        await HandleResponseAsync($"POST {path}", response);
        return (await response.Content.ReadFromJsonAsync<TResponse>())!;
    }

    public async Task PostAsync<TRequest>(string resource, TRequest request)
    {
        var path = GetBasePath(resource);
        var response = await _httpClient.PostAsJsonAsync(path, request);
        await HandleResponseAsync($"POST {path}", response);
    }

    public async Task<TResponse> PostAsync<TResponse>(string resource)
    {
        var path = GetBasePath(resource);
        var response = await _httpClient.PostAsync(path, default);
        await HandleResponseAsync($"POST {path}", response);
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
        var response = await _httpClient.SendAsync(request);
        await HandleResponseAsync($"DELETE {path}", response);
    }
    
    private string? GetBasePath(string resource)
    {
        return $"{_config.BaseUrl}/{resource}".Replace("//", "/");
    }

    private static string? NameValueCollectionToQueryString(NameValueCollection nameValueCollection)
    {
        return string.Join("&", nameValueCollection.AllKeys
            .Where(key => key != default)
            .Select(key => $"{Uri.EscapeDataString(key!)}={Uri.EscapeDataString(nameValueCollection[key]!)}"));
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