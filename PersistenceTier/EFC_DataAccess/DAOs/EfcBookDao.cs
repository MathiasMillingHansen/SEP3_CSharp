using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Domain;

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
}