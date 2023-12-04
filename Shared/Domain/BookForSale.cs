namespace Shared.Domain;

public class BookForSale
{
    public int Id { get; set; }
    public string Owner { get; set; }
    
    public decimal? Price { get; set; }
    
    public string ConditionState { get; set; }
    public Condition? Condition { get; set; }
    
    public string Comment { get; set; }
    public string BookIsbn { get; set; }
    public Book? Book { get; set; }

    public BookForSale()
    {
    }
}