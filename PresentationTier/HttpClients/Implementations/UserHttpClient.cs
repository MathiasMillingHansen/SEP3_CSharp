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

    public Task<string> LoginUser(string username, string password)
    {
        throw new NotImplementedException();
    }
}