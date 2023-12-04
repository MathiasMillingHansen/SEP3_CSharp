namespace Shared.Domain;

public class Author
{
    public string Name { get; set; }
    public int Id { get; set; }
    
    public ICollection<Book> books { get; set; }
    
    public Author(string name)
    {
        Name = name;
    }
    
    private Author()
    {
    }
}