using Shared.Domain;

namespace BusinessWebAPI.Application.DaoInterface;

public interface IBookDao
{
    public Task<Book> CreateAsync(Book book);
    
    Task<IEnumerable<Book>> GetAllAsync();

    Task<Book> GetByIsbnAsync(int isbn);

    Task<Book> GetByBookTitleAsync(string bookTitle);
}