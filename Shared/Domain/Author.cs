namespace Shared.Domain;

public class Author
{
    public string Name { get; set; }
    public int Id { get; set; }
    public Publisher Publisher { get; set; }
    
    public Author(string name, Publisher publisher)
    {
        Name = name;
        Publisher = publisher;
    } 
    
    private Author()
    {
    }
}