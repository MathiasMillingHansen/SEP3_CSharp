using System.Text.Json;
using BusinessWebAPI.Application.DaoInterface;
using Shared.Domain;
using Shared.DTOs;

namespace BusinessWebAPI.Application.DaoImplementation;

public class CatalogDao : ICatalogDao
{
    HttpClient client;
    
    public CatalogDao(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<BookCourseDto> GetByCourseAsync(string course)
    {
        HttpResponseMessage response = await client.GetAsync("/BookDB/" + course);
        string result = response.Content.ReadAsStringAsync().Result;
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        BookCourseDto bookCourseDto = JsonSerializer.Deserialize<BookCourseDto>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return bookCourseDto;
    }

    public async Task<ICollection<BooksAvailableDto>> GetAllAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/BookDB");
        string result = await response.Content.ReadAsStringAsync();
        
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
    
    
    public IEnumerable<BooksAvailableDto> SearchBooks(Book searchModel)
    {
        throw new NotImplementedException();
    }
}