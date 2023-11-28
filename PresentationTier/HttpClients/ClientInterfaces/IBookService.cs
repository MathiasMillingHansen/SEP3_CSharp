using Shared.Domain;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IBookService
{
    Task<Book> CreateAsync(BookSaleDto bookSaleDto);
    ICollection<BooksAvailableDto> GetAvailableBooksAsync();
    ICollection<Condition> GetConditionsAsync();
    Task<string> SellBookAsync(BookSaleDto bookSaleDto);
}