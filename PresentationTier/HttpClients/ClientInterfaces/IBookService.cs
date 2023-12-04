using Shared.Domain;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IBookService
{
    ICollection<BooksAvailableDto> GetAvailableBooksAsync();
    ICollection<Condition> GetConditionsAsync();
    Task<string> SellBookAsync(BookSaleDto bookSaleDto);
    Task<BooksForSaleDto> GetAllBooksForSaleAsync();
}