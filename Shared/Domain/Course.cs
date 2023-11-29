using System.ComponentModel.DataAnnotations;

namespace Shared.Domain;

public class Course
{
    [Key]
    public string CourseName { get; set; }
    
    public ICollection<Book> Books { get; set; }

    public Course(string course)
    {
        this.CourseName = course;
    }
    
    private Course()
    {
    }
}