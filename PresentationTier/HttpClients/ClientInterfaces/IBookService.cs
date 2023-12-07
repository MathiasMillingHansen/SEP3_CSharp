using Shared.Domain;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IBookService
{
    ICollection<BooksAvailableDto> GetAvailableBooksAsync();
    ICollection<Condition> GetConditionsAsync();
    Task<string> SellBookAsync(BookSaleDto bookSaleDto);
    Task<BooksForSaleDto> GetAllBooksForSaleAsync();
    Task<BooksForSaleDto> GetBooksByOwnerAsync(string owner);
    Task DeleteBookForSaleAsync(int bookForSale);
    
    Task<UserInfoDto> GetUserInfoAsync(string username);
}