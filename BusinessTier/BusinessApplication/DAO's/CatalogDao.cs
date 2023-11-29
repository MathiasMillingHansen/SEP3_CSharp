using System.Text.Json;
using BusinessWebAPI.Application.DaoInterface;
using Shared.Domain;
using Shared.DTOs;

namespace BusinessWebAPI.Application.DaoImplementation;

public class CatalogDao : ICatalogBook
{
    HttpClient client;
    
    public CatalogDao(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<BookCategoryDto> GetByCategoryAsync(string category)
    {
        HttpResponseMessage response = await client.GetAsync("/BookDB/" + category);
        string result = response.Content.ReadAsStringAsync().Result;
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        BookCategoryDto bookCategoryDto = JsonSerializer.Deserialize<BookCategoryDto>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return bookCategoryDto;
    }

    public Task<IEnumerable<Book>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}