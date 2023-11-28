using System.ComponentModel.DataAnnotations;

namespace Shared.Domain;

public class Author
{
    [Key]
    public string Name { get; set; }
    
    private Author()
    {
    }
}