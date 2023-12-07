using System.Net;
using System.Net.Http.Json;
using System.Security.AccessControl;
using System.Text.Json;
using System.Text.Json.Serialization;
using BusinessWebAPI.Application.DaoInterface;
using Shared.Domain;
using Shared.DTOs;

namespace BusinessWebAPI.Application.DaoImplementation;

public class SellDao : ISellDao
{
    
    HttpClient client;
    
    public SellDao(HttpClient client)
    {
        this.client = client;
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
    
    public async Task<string> SellBookAsync(BookForSale bookForSale)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/BookDB", bookForSale);
        string result = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        return result;
    }

    public async Task<BooksForSaleDto> GetBooksByOwnerAsync(string owner)
    {
        HttpResponseMessage response = await client.GetAsync("/BookDB/Owner/" + owner);
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

    public async Task DeleteBookForSaleAsync(int id)
    {
        HttpResponseMessage response = client.DeleteAsync("/BookDB/" + id).Result;
        string result = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        return;
    }
}