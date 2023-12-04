using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Domain;
using Shared.DTOs;
using SQLitePCL;

namespace EFC_DataAccess.DAOs;

public class EfcBookDao : IEfcBookDao
{
    private readonly DatabaseContext context;
    
    
    public EfcBookDao(DatabaseContext databaseContext)
    {
        context = databaseContext;
    }
    
    
    public async Task<Book> InsertAsync(Book book)
    {
        EntityEntry<Book> newBook = await context.books.AddAsync(book);
        await context.SaveChangesAsync();
        return newBook.Entity;
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await context.books.ToListAsync();
    }

    public async Task<ICollection<Condition>> GetConditionsAsync()
    {
        return await context.conditions.ToListAsync();
    }

    public async Task<BookDto> GetByIsbnAsync(string isbn)
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

        return bookDto;
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

    public void AttachAuthor(Author author)
    {
        context.authors.Attach(author);
    }

    public void AttachCourse(Course course)
    {
        context.courses.Attach(course);
    }

    public void AttachBook(Book book)
    {
        context.books.Attach(book);
    }

    public void AttachCondition(Condition condition)
    {
        context.conditions.Attach(condition);
    }
}