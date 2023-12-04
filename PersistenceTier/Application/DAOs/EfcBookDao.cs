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


}