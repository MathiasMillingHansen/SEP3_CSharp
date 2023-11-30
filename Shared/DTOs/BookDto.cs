using Shared.Domain;

namespace Shared.DTOs;

public class BookDto
{
    public string Isbn { get; set; }
    public string Title { get; set; }
    public ICollection<Author> Authors { get; set; }
    
    public ICollection<Course> Courses { get; set; }

    public BookDto()
    {

    }
}