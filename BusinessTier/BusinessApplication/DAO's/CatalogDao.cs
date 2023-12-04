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
    

    public async Task<ICollection<BookCourseDto>> GetByCourseAsync(string course)
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
        
        return null;
    }

    public async Task<BooksForSaleDto> GetAllBooksForSaleAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/BookDB/booksForSale");
        string result = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        BooksForSaleDto books = JsonSerializer.Deserialize<BooksForSaleDto>(result, new JsonSerializerOptions
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