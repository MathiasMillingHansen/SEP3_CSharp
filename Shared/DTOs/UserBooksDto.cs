namespace Shared.Domain;

public class UserBooksDto
{
    public string Username { get; set; }
    
    public ICollection<Book> Books { get; set; }
}