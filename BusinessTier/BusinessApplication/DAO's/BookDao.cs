using System.Net.Http.Json;
using System.Security.AccessControl;
using System.Text.Json;
using System.Text.Json.Serialization;
using BusinessWebAPI.Application.DaoInterface;
using Shared.Domain;
using Shared.DTOs;

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

    public async Task<ICollection<BooksAvailableDto>> GetAllAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/BookDB");
        string result = response.Content.ReadAsStringAsync().Result;
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        ICollection<BooksAvailableDto> books = JsonSerializer.Deserialize<ICollection<BooksAvailableDto>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return books;
    }

    public async Task<BookWrapperDto> GetByIsbnAsync(string isbn)
    {
        HttpResponseMessage response = await client.GetAsync("/BookDB/" + isbn);
        string result = response.Content.ReadAsStringAsync().Result;
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        BookWrapperDto bookWrapperDto = JsonSerializer.Deserialize<BookWrapperDto>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return bookWrapperDto;
    }

    public Task<Book> GetByBookTitleAsync(string bookTitle)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Condition>> GetConditionsAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/BookDB/conditions");
        string result = response.Content.ReadAsStringAsync().Result;
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        ICollection<Condition> conditions = JsonSerializer.Deserialize<ICollection<Condition>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return conditions;
        
    }
}