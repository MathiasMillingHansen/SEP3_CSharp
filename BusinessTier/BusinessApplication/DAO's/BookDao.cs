using System.Net.Http.Json;
using System.Security.AccessControl;
using System.Text.Json;
using System.Text.Json.Serialization;
using BusinessWebAPI.Application.DaoInterface;
using Shared.Domain;

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
        HttpResponseMessage response = await client.PostAsJsonAsync("/BookDB", book);
        string result = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        Book created = JsonSerializer.Deserialize<Book>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return created;

    }

    public Task<IEnumerable<Book>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetByIsbnAsync(int isbn)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetByBookTitleAsync(string bookTitle)
    {
        throw new NotImplementedException();
    }
}