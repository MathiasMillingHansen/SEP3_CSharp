using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class UserHttpClient : IUserService
{
    
    private readonly HttpClient _httpClient;

    public UserHttpClient(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("UserHttpClient");
    }
    
    public Task RegisterUserAsync(string username, string password, string phoneNumber, string email)
    {
        throw new NotImplementedException();
    }

    public Task<string> LoginUser(string username, string password)
    {
        throw new NotImplementedException();
    }
}