using System.ComponentModel.DataAnnotations;

namespace Shared.Domain;

public class Author
{
    [Key]
    public string Name { get; set; }
    
    public Author(string name)
    {
        Name = name;
    } 
    
    private Author()
    {
    }
}