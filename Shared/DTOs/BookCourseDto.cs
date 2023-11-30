using Shared.Domain;

namespace Shared.DTOs;

public class BookCourseDto
{
    public Book book { get; set; }
    
    public string Course { get; set; }

    public BookCourseDto(string course)
    {
        Course = course;
    }
}