using Shared.Domain;
using Shared.DTO_s;

namespace BusinessWebAPI.Application.DaoInterface;

public interface IBookDao
{
    Task<Book> CreateAsync(Book book);

    Task<IEnumerable<Book>> GetAllAsync();

    Task<Book> GetByNameAsync(string bookName);

    Task<Book> GetByIsbnAsync(int isbn);
}