using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Domain;

namespace EFC_DataAccess.DAOs;

public class EfcBookForSaleDao : IEfcBookForSaleDao
{
    private readonly DatabaseContext context;
    
    public EfcBookForSaleDao(DatabaseContext databaseContext)
    {
        context = databaseContext;
        DatabaseInitializer.Initialize(context); //TODO: Might be fishy
    }
    
    public async Task<BookForSale> InsertAsync(BookForSale bookForSale)
    {
        EntityEntry<BookForSale> newBookForSale = await context
            .booksForSale
            .AddAsync(bookForSale);
        await context.SaveChangesAsync();
        return newBookForSale.Entity;
    }
    
    public async Task<ICollection<BookForSale>> GetAllBooksForSaleAsync()
    {
        List<BookForSale> booksForSale = await context.booksForSale
            .Include(bfs => bfs.Book)
            .ThenInclude(bfs => bfs.Authors).Include(bfs => bfs.Book.courses)
            .Include(c => c.Condition)
            .ToListAsync();

        return booksForSale;
    }
}