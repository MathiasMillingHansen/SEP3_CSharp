using Shared.Domain;
using Shared.DTOs;

namespace EFC_DataAccess.DAOs;

public interface IEfcBookDao
{
    Task<Book> InsertAsync(Book book);
    Task<List<Book>> GetAllAsync();
    Task<ICollection<Condition>> GetConditionsAsync();
    Task<Book> GetByIsbnAsync(string isbn);
    Task<BooksForSaleDto> GetBooksByOwnerAsync(string owner);
    Task DeleteBookForSaleAsync(int bookForSale);
}