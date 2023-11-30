using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Shared.Domain;

public class Course
{
    [Key]
    public string CourseName { get; set; }
    
    public ICollection<Book>? Books { get; set; }

    public Course(string course)
    {
        this.CourseName = course;
    }

    public Course(string course, ICollection<Book> books)
    {
        CourseName = course;
        Books = books;
    }

    public Course()
    {
        
    }
    
    
    
    
}