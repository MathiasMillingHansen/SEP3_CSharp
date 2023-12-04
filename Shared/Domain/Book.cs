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
    
    public Book(string isbn, string bookTitle, ICollection<Author> authors, string edition, ICollection<Course> courses)
    {
        Isbn = isbn;
        BookTitle = bookTitle;
        Authors = authors;
        Edition = edition;
        this.courses = courses;
    }

    public String GetAuthorsAsString()
    {
        String allAuthors = new string("");
        foreach (Author author in Authors)
        {
            if (Authors.Count == 1)
            {
                allAuthors = author.Name;
            }
            else
            {
                allAuthors += author.Name + ", ";
            }

        }

        return allAuthors;
    }
}
