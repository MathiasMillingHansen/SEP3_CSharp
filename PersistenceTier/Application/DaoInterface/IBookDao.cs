using Shared.Domain;

namespace Application.DaoInterface;

public interface IBookDao
{
    Task<Book> CreateAsync(Book book);
}