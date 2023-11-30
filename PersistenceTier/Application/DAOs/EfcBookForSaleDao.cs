using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Domain;
using Shared.DTOs;

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

    public async Task<BooksForSaleDto> GetAllAsync()
    { 
        ICollection<BookForSale> booksforsale = await context.booksForSale
            .Include(bfs => bfs.Book)
            .Include(b =>b.Book.Authors)
            .Include(b=> b.Book.courses)
            .Include(bfs => bfs.Condition)
            .ToListAsync();
        BooksForSaleDto booksToReturn = new BooksForSaleDto(booksforsale);
        return booksToReturn;
    }
}