namespace Shared.Domain;

public class Course
{
    public string course { get; set; }

    public Course(string course)
    {
        this.course = course;
    }
    
    private Course()
    {
    }
}