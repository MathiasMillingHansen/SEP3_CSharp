using Shared.Domain;

namespace Shared.DTOs;

public class BookCourseDto
{
    public Book book { get; set; }
    
    public string Category { get; set; }

    public BookCourseDto(string category)
    {
        Category = category;
    }
}