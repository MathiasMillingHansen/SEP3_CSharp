using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shared.Domain;

public class Course
{
    [Key]
    public string Name { get; set; }
    
    public ICollection<Book> Books { get; set; }

    public Course(string course)
    {
        this.Name = course;
    }
    
    private Course()
    {
    }
}