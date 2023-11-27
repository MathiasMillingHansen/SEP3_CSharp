namespace Shared.Domain;

public class UserInformation
{
    public string Username { get; set; }
    
    public ICollection<Book> Books { get; set; }
}