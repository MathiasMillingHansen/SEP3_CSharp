using System.ComponentModel.DataAnnotations;

namespace Shared.Domain;

public class Book
{
    [Key]
    public int Isbn { get; set; }

    public string BookTitle { get; set; }

    public string Author { get; set; }

    public string Edition { get; set; }

    public int PageCount { get; set; }

    [Key]
    public string Owner { get; set; }

    public string Condition { get; set; }

    public string Comment { get; set; }

    public string Category { get; set; }
    
    public decimal Price { get; set; }

    public Book(int isbn, string bookTitle, string author, string edition, int pageCount, string owner,
        string condition, string comment, string category, decimal price)
    {
        Isbn = isbn;
        BookTitle = bookTitle;
        Author = author;
        Edition = edition;
        PageCount = pageCount;
        Owner = owner;
        Condition = condition;
        Comment = comment;
        Category = category;
        Price = price;
    }
    
    private Book()
    {
    }
}