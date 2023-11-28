namespace Shared.Domain;

public class BookForSale
{
    public string Owner { get; set; }
    
    public decimal? Price { get; set; }
    
    public Condition Condition { get; set; }
    
    public string Comment { get; set; }
    
    public Book Book { get; set; }

    public BookForSale()
    {
    }
}