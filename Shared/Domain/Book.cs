using System.ComponentModel.DataAnnotations;
using Shared.DTOs;

namespace Shared.Domain;

public class Book
{
    [Key]
    public int Isbn { get; set; }
    
    public string BookTitle { get; set; }
    
    public ICollection<Author> Authors { get; set; }
    
    public string Edition { get; set; }

    public ICollection<Course> courses;

    public Book(ICollection<Course> courses, int isbn, string bookTitle, ICollection<Author> authors, string edition)
    {
        this.courses = courses;
        Isbn = isbn;
        BookTitle = bookTitle;
        Authors = authors;
        Edition = edition;
    }

    private Book() {}
}
