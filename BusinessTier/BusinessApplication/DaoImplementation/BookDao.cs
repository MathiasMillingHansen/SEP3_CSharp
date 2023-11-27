using BusinessWebAPI.Application.DaoInterface;
using Shared.Domain;
using Shared.DTO_s;

namespace BusinessWebAPI.Application.DaoImplementation;

public class BookDao : IBookDao
{
    public Task<Book> CreateAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetByNameAsync(string bookName)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetByIsbnAsync(int isbn)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetByTitleAsync(string postTitle)
    {
        throw new NotImplementedException();
    }
    
}