using System.ComponentModel.DataAnnotations;

namespace Shared.Domain;

public class Author
{
    public string Name { get; set; }
    public int Id { get; set; }
    
    private Author()
    {
    }
}