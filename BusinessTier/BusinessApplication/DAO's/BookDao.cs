using System.Security.AccessControl;
using System.Text.Json;
using System.Text.Json.Serialization;
using BusinessWebAPI.Application.DaoInterface;
using Shared.Domain;
using Shared.DTO_s;

namespace BusinessWebAPI.Application.DaoImplementation;

public class BookDao : IBookDao
{
    
    HttpClient client;
    
    public BookDao(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<Book> CreateAsync(Book book)
    {
        // HttpResponseMessage httpResponseMessage = await client.GetAsync("User");
        // String response = await httpResponseMessage.Content.ReadAsStringAsync();
        // Console.WriteLine(response + "is the response message");
        // ICollection<GetUserDto> users = JsonSerializer.Deserialize<ICollection<GetUserDto>>(response, new JsonSerializerOptions
        // {
        //     WriteIndented = true,
        //     PropertyNameCaseInsensitive = true
        //     
        //     
        // });
        // foreach (var user in users)
        // {
        //     Console.WriteLine(user.Username);
        // }
        // return users;

        throw new NotImplementedException();
    }

}