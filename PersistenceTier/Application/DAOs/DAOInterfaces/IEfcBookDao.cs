using Shared.Domain;
using Shared.DTOs;

namespace EFC_DataAccess.DAOs;

public interface IEfcBookDao
{
    Task<Book> InsertAsync(Book book);
    Task<List<Book>> GetAllAsync();
    Task<ICollection<Condition>> GetConditionsAsync();
    Task<BookWrapperDto> GetByIsbnAsync(string isbn);
}