using Shared.Domain;

namespace BusinessWebAPI.Application.DaoInterface;

public interface IBookDao
{
    public Task<Book> CreateAsync(Book book);
}