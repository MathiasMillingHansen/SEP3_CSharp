using Microsoft.EntityFrameworkCore;
using Shared.Domain;

namespace EFC_DataAccess;

public class DatabaseContext : DbContext
{
    public DbSet<Book> books { get; set; }
    public DbSet<Author> authors { get; set; }
    public DbSet<Publisher> publishers { get; set; }
    
    private readonly string connectionString = "Host=localhost;Database=postgres;Username=postgres;Password=1234";
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);            
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasKey(book => new { book.Isbn, book.Owner });
    }
}