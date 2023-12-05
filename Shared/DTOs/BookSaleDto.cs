using Shared.Domain;

namespace Shared.DTOs;

public class BookSaleDto
{
    public string? Isbn { get; set; }
    public string? Owner { get; set; }
    
    public Condition? BookCondition { get; set; }
    public string? Comment { get; set; }
    public decimal? Price { get; set; }
    
    public string? Edition { get; set; }
    
    public BookSaleDto ()
    {
    }
    
    
}