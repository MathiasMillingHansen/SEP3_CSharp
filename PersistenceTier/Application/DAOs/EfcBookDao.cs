using CachingConext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Domain;
using Shared.DTOs;
using SQLitePCL;

namespace EFC_DataAccess.DAOs;

public class EfcBookDao : IEfcBookDao
{
    private readonly DatabaseContext context;
    BookCache bookCache;
    
    
    public EfcBookDao(DatabaseContext databaseContext)
    {
        context = databaseContext;
        bookCache = new BookCache();
    }
    
    
    public async Task<Book> InsertAsync(Book book)
    {
        EntityEntry<Book> newBook = await context.books.AddAsync(book);
        await context.SaveChangesAsync();
        return newBook.Entity;
    }

    public async Task<List<Book>> GetAllAsync()
    {
        if(bookCache.CachedBooks.Count > 0)
        {
            return bookCache.CachedBooks.ToList();
        }
        else
        {
            List<Book> books = await context.books.ToListAsync();
            bookCache.CachedBooks = books;
            return books;
        }
    }

    public async Task<ICollection<Condition>> GetConditionsAsync()
    {
        return await context.conditions.ToListAsync();
    }

    public async Task<Book> GetByIsbnAsync(string isbn)
    {
        
        // Fetch the book with the specified ISBN
        var book = await context.books
            .Where(b => b.Isbn == isbn)
            .FirstOrDefaultAsync();

        // Check if a book was found
        if (book == null)
        {
            return null;
        }

        // Fetch the related Authors and Courses
        var authors = await context.authors
            .Where(a => a.books.Any(b => b.Isbn == book.Isbn))
            .ToListAsync();

        var courses = await context.courses
            .Where(c => c.Books.Any(b => b.Isbn == book.Isbn))
            .ToListAsync();

        // Map the Book, Authors, and Courses to a BookDto object
        var bookDto = new BookDto
        {
            Isbn = book.Isbn,
            Title = book.BookTitle,
            Authors = authors,
            Courses = courses
        };

        return book;
    }

    public async Task<BooksForSaleDto> GetBooksByOwnerAsync(string owner)
    {
        List<BookForSale> books = await context.booksForSale
            .Where(b => b.Owner == owner)
            .Include(b => b.Condition)
            .Include(b => b.Book)
            .ThenInclude(bb => bb.Authors)
            .Include(b => b.Book.courses)
            .ToListAsync();
        
        BooksForSaleDto booksForSaleDto = new BooksForSaleDto(books);
        return booksForSaleDto;
    }

    public async Task DeleteBookForSaleAsync(int id)
    {
        context.booksForSale.Remove(await context.booksForSale.FindAsync(id));
        await context.SaveChangesAsync();
    }

    public async Task<BookForSale> SellBookAsync(BookForSale bookForSale)
    {
        try
        {
            context.booksForSale.AddAsync(bookForSale);
            Console.WriteLine("BookForSale added to context");
            return bookForSale;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
    
}