using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Domain;

namespace EFC_DataAccess.DAOs;

public class EfcAuthorDao : IEfcAuthorDao
{
    private readonly DatabaseContext context;
    
    
    public EfcAuthorDao(DatabaseContext databaseContext)
    {
        context = databaseContext;
    }
    
    
    public async Task<Author> InsertAsync(Author author)
    {
        EntityEntry<Author> newAuthor = await context.authors.AddAsync(author);
        await context.SaveChangesAsync();
        return newAuthor.Entity;
    }
}