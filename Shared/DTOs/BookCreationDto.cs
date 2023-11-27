namespace Shared.DTOs;

public class BookCreationDto
{
    public int Isbn { get; set; }
    
    public string BookTitle { get; set; }
    
    public string Author { get; set; }
    
    public string Edition { get; set; }
    
    public int? PageCount { get; set; }
    
    public string Owner { get; set; }
    
    public string Condition { get; set; }
    
    public string? Comment { get; set; }
    
    public string? Category { get; set; }
    
    public int? Price { get; set; }

    public BookCreationDto(int isbn, string bookTitle, string author, string edition, int? pageCount, 
        string owner, string condition, string? comment, string? category, int? price)
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
}