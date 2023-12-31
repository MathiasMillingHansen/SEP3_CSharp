﻿using Microsoft.EntityFrameworkCore;
using Shared.Domain;
using Shared.DTOs;

namespace EFC_DataAccess;

public class DatabaseContext : DbContext
{
    public DbSet<Book> books { get; set; }
    public DbSet<Author> authors { get; set; }
    
    public DbSet<Course> courses { get; set; }
    
    public DbSet<Condition> conditions { get; set; }
    
    public DbSet<BookForSale> booksForSale { get; set; }
    
    private readonly string connectionString = "Host=cornelius.db.elephantsql.com;Database=pexjxujf;Username=pexjxujf;Password=VEu6worirTNw0TWGnTniNrx2C0iYYB2-";
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);            
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Books");
    }
}