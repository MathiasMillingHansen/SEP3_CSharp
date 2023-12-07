using Shared.Domain;
using Shared.DTOs;

namespace BusinessWebAPI.Application.DaoInterface;

public interface ISellDao
{
    Task<ICollection<BooksAvailableDto>> GetAllAsync();
    Task<BookWrapperDto> GetByIsbnAsync(string isbn);
    Task<ICollection<Condition>> GetConditionsAsync();
    Task<string> SellBookAsync(BookForSale bookForSale);
    Task<BooksForSaleDto> GetBooksByOwnerAsync(string owner);
    Task DeleteBookForSaleAsync(int bookForSale);
}