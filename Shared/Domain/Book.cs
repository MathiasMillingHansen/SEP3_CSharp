using System.ComponentModel.DataAnnotations;
using Shared.DTOs;

namespace Shared.Domain;

public class Book
{
    [Key]
    public int Isbn { get; set; }
    
    public string BookTitle { get; set; }
    
    public ICollection<AuthorDto> Authors { get; set; }
    
    public string Edition { get; set; }
    
    public int? PageCount { get; set; }
    
    [Key]
    public string Owner { get; set; }
    
    public string Condition { get; set; }
    
    public string? Comment { get; set; }
    
    public string? Category { get; set; }
    
    public decimal? Price { get; set; }

    public Book(int isbn, string bookTitle, ICollection<AuthorDto> authors, string edition,
        int? pageCount, string owner, string condition, string? comment, string? category, decimal? price)
    {
        Isbn = isbn;
        BookTitle = bookTitle;
        Authors = authors;
        Edition = edition;
        PageCount = pageCount;
        Owner = owner;
        Condition = condition;
        Comment = comment;
        Category = category;
        Price = price;
    }
    
    public Book() {}
}