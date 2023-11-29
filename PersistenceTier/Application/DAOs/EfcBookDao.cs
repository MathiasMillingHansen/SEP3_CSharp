using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Domain;
using Shared.DTOs;

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

    public Task<BookWrapperDto> GetByIsbnAsync(string isbn)
    {
        throw new NotImplementedException();
    }
}