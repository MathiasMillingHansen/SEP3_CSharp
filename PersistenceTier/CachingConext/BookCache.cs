using Shared.Domain;

namespace CachingConext;


public class BookCache
{
    public ICollection<Book> CachedBooks { get; set; } = new List<Book>();

    public void AddBook(Book book)
    {
        CachedBooks.Add(book);
    }
}