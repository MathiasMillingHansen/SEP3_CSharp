using Shared.Domain;
using Shared.DTOs;

namespace Logic.LogicInterface;

public interface ISellLogic
{
    Task<ICollection<BooksAvailableDto>> GetAllAsync();
    Task<ICollection<Condition>> GetConditionsAsync();
    Task<Book> GetByIsbnAsync(string isbn);
    Task<string> SellBookAsync(BookForSale dto);
    Task<ICollection<BookForSale>> GetAllBooksForSaleAsync();
    Task<BooksForSaleDto> GetBooksByOwnerAsync(string owner);
    Task DeleteBookForSaleAsync(int bookForSale);
    Task EditBookForSaleAsync(EditBookForSaleDto dto);
}