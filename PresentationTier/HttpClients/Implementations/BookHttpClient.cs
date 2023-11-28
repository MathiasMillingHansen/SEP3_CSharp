using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared.Domain;
using Shared.DTOs;

namespace HttpClients.Implementations;

public class BookHttpClient : IBookService
{
    private readonly HttpClient _httpClient;
    
    public BookHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public ICollection<BooksAvailableDto> GetAvailableBooksAsync()
    {
        HttpResponseMessage response = _httpClient.GetAsync("/books").Result;
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

    public ICollection<Condition> GetConditionsAsync()
    {
        HttpResponseMessage response = _httpClient.GetAsync("/conditions").Result;
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

    public async Task<string> SellBookAsync(BookSaleDto bookSaleDto)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/book", bookSaleDto);
        string result = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        return result;
    }
}