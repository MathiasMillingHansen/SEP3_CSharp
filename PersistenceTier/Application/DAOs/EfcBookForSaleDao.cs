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
    
    public async Task<string> InsertAsync(BookForSale bookForSale)
    {
        EntityEntry<BookForSale> newBookForSale = await context
            .booksForSale
            .AddAsync(bookForSale);
        await context.SaveChangesAsync();
        return "Book successfully listed!";
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
    
    public async Task EditBookForSaleAsync(EditBookForSaleDto dto)
    {
        BookForSale bookToEdit = await context.booksForSale.FindAsync(dto.Id);
        bookToEdit.Price = dto.Price;
        bookToEdit.Comment = dto.Comment;
        bookToEdit.Condition = dto.Condition;
        context.Entry(bookToEdit).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }
}