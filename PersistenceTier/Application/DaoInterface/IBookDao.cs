using Shared.Domain;
using Shared.DTO_s;

namespace Application.DaoInterface;

public interface IBookDao
{
    Task<Book> CreateAsync(Book book);
}