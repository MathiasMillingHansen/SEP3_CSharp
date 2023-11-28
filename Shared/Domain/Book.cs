using System.ComponentModel.DataAnnotations;
using Shared.DTOs;

namespace Shared.Domain;

public class Book
{
    [Key]
    public string Isbn { get; set; }
    public string BookTitle { get; set; }
    public ICollection<Author> Authors { get; set; }
    public string Edition { get; set; }
    public ICollection<Course> courses { get; set; }

    public Book() {}
}
