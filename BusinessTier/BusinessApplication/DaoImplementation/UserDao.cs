using System.Security.AccessControl;
using System.Text.Json;
using System.Text.Json.Serialization;
using BusinessWebAPI.Application.DaoInterface;
using Shared.DTO_s;

namespace BusinessWebAPI.Application.DaoImplementation;

public class UserDao : IUserDao
{
    
    HttpClient client;
    
    public UserDao(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<ICollection<GetUserDto>> GetUsersAsync()
    {
        HttpResponseMessage httpResponseMessage = await client.GetAsync("User");
        String response = await httpResponseMessage.Content.ReadAsStringAsync();
        Console.WriteLine(response + "is the response message");
        ICollection<GetUserDto> users = JsonSerializer.Deserialize<ICollection<GetUserDto>>(response, new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
            
            
        });
        foreach (var user in users)
        {
            Console.WriteLine(user.Username);
        }
        return users;
    }
}