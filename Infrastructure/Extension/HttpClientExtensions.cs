using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infrastructure.Extension;

public static class HttpClientExtensions
{
    private static async Task<T?> ReadAsJsonAsync<T>(this HttpResponseMessage response,
        bool returnException, JsonSerializerOptions? options)
    {
        var task = await response.ReadAsJsonAsync();

        if (returnException)
        {
            var statusCodeString = ((int)task.StatusCode).ToString();
            if (!statusCodeString.StartsWith("2"))
            {
                var exception = await task.Content.ReadAsStringAsync();
                var exceptionMessage = JsonSerializer.Serialize(exception);
                Console.WriteLine(exceptionMessage);
            }
        }

        if (typeof(T) == typeof(HttpResponseMessage))
            return (T)(object)task;

        options ??= new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new JsonStringEnumConverter());
        var json = await response.Content.ReadAsStringAsync();
        json = string.IsNullOrEmpty(json) ? "{}" : json;
        T? result;
        try
        {
            result = JsonSerializer.Deserialize<T?>(json, options);
        }
        catch (Exception e)
        {
            e.Data.Add("Url", task.RequestMessage?.RequestUri);
            e.Data.Add("Method", task.RequestMessage?.Method);
            e.Data.Add("Headers", task.RequestMessage?.Headers);
            e.Data.Add("StatusCode", task.StatusCode);
            e.Data.Add("Reason", task.ReasonPhrase);
            SentrySdk.CaptureException(e);
            Console.WriteLine(e);
            throw;
        }
        return result;
    }

    private static Task<HttpResponseMessage> ReadAsJsonAsync(this HttpResponseMessage response)
    {
        return Task.FromResult(response);
    }

    public static async Task<T?> GetAsJsonAsync<T>(this HttpClient httpClient, string url,
            Dictionary<string, string>? headers = null, AuthenticationHeaderValue? authenticationHeader = null,
            bool includeContentLengthZero = true, bool returnException = true, JsonSerializerOptions? options = null)
    {
        using var message = new HttpRequestMessage(HttpMethod.Get, url);
        message.Headers.Authorization = authenticationHeader;

        // Optionally include Content-Length header
        if (includeContentLengthZero)
        {
            message.Content = new StringContent(string.Empty);
            message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            message.Content.Headers.ContentLength = 0;
        }

        foreach (KeyValuePair<string, string> header in headers ?? new Dictionary<string, string>())
            message.Headers.Add(header.Key, header.Value);

        var response = await httpClient.SendAsync(message);

        return await response.ReadAsJsonAsync<T>(returnException, options: options);
    }

    public static async Task<byte[]> GetAsFile(this HttpClient httpClient, string url,
        Dictionary<string, string>? headers = null, AuthenticationHeaderValue? authenticationHeader = null)
    {
        using var message = new HttpRequestMessage(HttpMethod.Get, url);
        message.Headers.Authorization = authenticationHeader;

        foreach (KeyValuePair<string, string> header in headers ?? new Dictionary<string, string>())
            message.Headers.Add(header.Key, header.Value);

        var response = await httpClient.SendAsync(message);

        return await response.Content.ReadAsByteArrayAsync();
    }

    public static async Task<T?> PostAsJsonAsync<T>(this HttpClient httpClient,
        string url,
        object? content = null,
        Dictionary<string, string>? headers = null,
        AuthenticationHeaderValue? authenticationHeader = null,
        bool includeContentType = true,
        bool isSerialized = false,
        bool returnException = true,
        JsonSerializerOptions? jsonSerializerOptions = null)
    {
        using var message = new HttpRequestMessage(HttpMethod.Post, url);
        message.Headers.Authorization = authenticationHeader;
        var json = JsonSerializer.Serialize(content);
        foreach (KeyValuePair<string, string> header in headers ?? new Dictionary<string, string>())
            message.Headers.TryAddWithoutValidation(header.Key, header.Value);
        if (isSerialized)
            json = content.ToString();
        message.Content =
            new StringContent(json, Encoding.UTF8, "application/json");
        if (includeContentType)
            message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = await httpClient.SendAsync(message);

        return await response.ReadAsJsonAsync<T>(returnException, options: jsonSerializerOptions);
    }

    public static async Task<T?> PostAsFormDataAsync<T>(this HttpClient httpClient, string url,
        Dictionary<string, string>? content = null,
        Dictionary<string, string>? headers = null, AuthenticationHeaderValue? authenticationHeader = null,
        bool returnException = true, JsonSerializerOptions? options = null)
    {
        using var message = new HttpRequestMessage(HttpMethod.Post, url);
        message.Headers.Authorization = authenticationHeader;

        foreach (KeyValuePair<string, string> header in headers ?? new Dictionary<string, string>())
            message.Headers.Add(header.Key, header.Value);

        if (content != null)
            message.Content =
                new FormUrlEncodedContent(content);

        var response = await httpClient.SendAsync(message);

        return await response.ReadAsJsonAsync<T>(returnException, options);
    }

    public static async Task<byte[]> PostAsFile(this HttpClient httpClient, string url, object? content = null,
        Dictionary<string, string>? headers = null, AuthenticationHeaderValue? authenticationHeader = null,
        JsonSerializerOptions? jsonSerializerOptions = null)
    {
        using var message = new HttpRequestMessage(HttpMethod.Post, url);
        message.Headers.Authorization = authenticationHeader;

        foreach (KeyValuePair<string, string> header in headers ?? new Dictionary<string, string>())
            message.Headers.Add(header.Key, header.Value);

        message.Content =
            new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");

        var response = await httpClient.SendAsync(message);

        return await response.Content.ReadAsByteArrayAsync();
    }

    public static async Task<T?> PutAsJsonAsync<T>(this HttpClient httpClient, string url, object? content = null,
        Dictionary<string, string>? headers = null, AuthenticationHeaderValue? authenticationHeader = null,
        bool returnException = true, JsonSerializerOptions? jsonSerializerOptions = null)
    {
        using var message = new HttpRequestMessage(HttpMethod.Put, url);
        message.Headers.Authorization = authenticationHeader;

        foreach (var header in headers ?? new Dictionary<string, string>())
            message.Headers.Add(header.Key, header.Value);

        var json = JsonSerializer.Serialize(content);
        message.Content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.SendAsync(message);

        return await response.ReadAsJsonAsync<T>(returnException, options: jsonSerializerOptions);
    }

    public static async Task<T?> DeleteAsJsonAsync<T>(this HttpClient httpClient, string url,
        Dictionary<string, string>? headers = null, AuthenticationHeaderValue? authenticationHeader = null,
        bool includeContentLengthZero = true, bool returnException = true, JsonSerializerOptions? jsonSerializerOptions = null)
    {
        using var message = new HttpRequestMessage(HttpMethod.Delete, url);
        message.Headers.Authorization = authenticationHeader;

        foreach (KeyValuePair<string, string> header in headers ?? new Dictionary<string, string>())
            message.Headers.Add(header.Key, header.Value);
        if (includeContentLengthZero)
        {
            message.Content = new StringContent(string.Empty);
            message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            message.Content.Headers.ContentLength = 0;
        }

        var response = await httpClient.SendAsync(message);

        return await response.ReadAsJsonAsync<T>(returnException, options: jsonSerializerOptions);
    }
}