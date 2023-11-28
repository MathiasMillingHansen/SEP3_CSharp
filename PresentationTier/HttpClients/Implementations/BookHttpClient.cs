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
    
    public async Task<Book> CreateAsync(BookSaleDto bookSaleDto)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/book", bookSaleDto);
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        Book book = JsonSerializer.Deserialize<Book>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return book;
    }
}