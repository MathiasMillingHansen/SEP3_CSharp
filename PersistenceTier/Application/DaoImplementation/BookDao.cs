using Application.DaoInterface;
using Shared.Domain;

namespace Application.DaoImplementation;

public class BookDao : IBookDao
{
    
    //TODO REMOVE
    private ICollection<Book> books = new List<Book>();
    
    public BookDao()
    {
    }

    public Task<Book> CreateAsync(Book book)
    {
        books.Add(book);
        return Task.FromResult(book);
    }
}