namespace Shared.Domain;

public class User
{
    public int Id { get; set; }
    
    public string Username { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public ICollection<Book> Books { get; set; }
}