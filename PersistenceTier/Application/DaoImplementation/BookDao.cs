using Application.DaoInterface;
using Shared.Domain;

namespace Application.DaoImplementation;

public class BookDao : IBookDao
{
    
    public BookDao()
    {
    }

    public Task<Book> CreateAsync(Book book)
    {
        throw new NotImplementedException();
    }
}