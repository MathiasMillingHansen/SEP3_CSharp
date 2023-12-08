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
        HttpResponseMessage response = _httpClient.GetAsync("/book").Result;
        string result = response.Content.ReadAsStringAsync().Result;
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        ICollection<BooksAvailableDto> books = JsonSerializer.Deserialize<ICollection<BooksAvailableDto>>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

        return books;
    }

    public ICollection<Condition> GetConditionsAsync()
    {
        HttpResponseMessage response = _httpClient.GetAsync("/book/conditions").Result;
        string result = response.Content.ReadAsStringAsync().Result;
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        ICollection<Condition> conditions = JsonSerializer.Deserialize<ICollection<Condition>>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

        return conditions;
    }

    public async Task<string> SellBookAsync(BookSaleDto bookSaleDto)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/book", bookSaleDto);
        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception(errorResponse);
        }

        string result = await response.Content.ReadAsStringAsync();
        return result;
    }
    
    public async Task<BooksForSaleDto> GetAllBooksForSaleAsync()
    {
        HttpResponseMessage response = _httpClient.GetAsync("/Catalog").Result;
        string result = response.Content.ReadAsStringAsync().Result;
        
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

    public async Task<BooksForSaleDto> GetBooksByOwnerAsync(string owner)
    {
        HttpResponseMessage response = _httpClient.GetAsync("/book/owner/" + owner).Result;
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
        HttpResponseMessage response = _httpClient.DeleteAsync("/Book/" + id).Result;
        string result = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        return;
    }
    
    public async Task EditBookForSaleAsync(EditBookForSaleDto dto)
    {
        HttpResponseMessage response = await _httpClient.PatchAsJsonAsync("/editBook", dto);
        string result = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
    }
}