namespace Shared.Domain;

public class Publisher
{
    public string Name { get; set; } 
    public int Id { get; set; }
    
    public Publisher(string name)
    {
        Name = name;
    }
    
    private Publisher()
    {
    }
}