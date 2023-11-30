using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shared.Domain;

public class Course
{
    [Key]
    public string CourseName { get; set; }
    
    //[JsonIgnore]
    public ICollection<Book> Books { get; set; }

    public Course(string course)
    {
        this.CourseName = course;
    }
    
    private Course()
    {
    }
}