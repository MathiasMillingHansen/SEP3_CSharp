using System.Net.Http.Json;
using HttpClients.ClientInterfaces;
using Shared.DTOs;

namespace HttpClients.Implementations;

public class UserHttpClient : IUserService
{
    
    private readonly HttpClient _httpClient;

    public UserHttpClient(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("UserHttpClient");
    }
    
    public async Task<string> RegisterUserAsync(RegisterDto registerDto)
    {
        HttpResponseMessage response = _httpClient.PostAsJsonAsync("register", registerDto).Result;
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        return result;
    }

    public async Task<string> LoginUser(LoginDto loginDto)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "login")
        {
            Content = JsonContent.Create(loginDto)
        };
        HttpResponseMessage response = _httpClient.SendAsync(request).Result;
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        return result;
    }
}